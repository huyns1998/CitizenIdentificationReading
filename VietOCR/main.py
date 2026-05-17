import PIL.Image
import PIL

# --- PHẦN VÁ LỖI (MONKEY PATCH) ---
# Dứt điểm lỗi 'module PIL.Image has no attribute ANTIALIAS' do Pillow 10+
if not hasattr(PIL.Image, 'ANTIALIAS'):
    # Gán ANTIALIAS trỏ về Resampling.LANCZOS (tương đương về chất lượng)
    PIL.Image.ANTIALIAS = PIL.Image.Resampling.LANCZOS
    # Đảm bảo các thư viện bên thứ 3 (như VietOCR) tìm thấy thuộc tính này
    setattr(PIL.Image, 'ANTIALIAS', PIL.Image.Resampling.LANCZOS)
# ----------------------------------

from fastapi import FastAPI, UploadFile, File, HTTPException
from paddleocr import PaddleOCR
from vietocr.tool.predictor import Predictor
from vietocr.tool.config import Cfg
from PIL import Image
import shutil
import uuid
import os
import cv2
import numpy as np

app = FastAPI()

# 1. Khởi tạo PaddleOCR - Chỉ dùng Detection (Tìm vùng chữ)
ocr_det = PaddleOCR(
    use_angle_cls=True,
    lang='vi',
    use_gpu=False,
    show_log=False,
    rec=False,
    # Giảm unclip_ratio để box ôm sát chữ hơn, tránh liếm vào hoa văn nền
    det_db_unclip_ratio=1.6, 
    # Tăng thresh để loại bỏ các đốm nhiễu nhỏ (các chữ "thuật, thái" thường từ đây)
    det_db_box_thresh=0.6,
    det_db_thresh=0.3
)

# 2. Khởi tạo VietOCR - Dùng Recognition (Nhận diện chữ Tiếng Việt)
config = Cfg.load_config_from_name('vgg_transformer')
config['device'] = 'cpu'
ocr_rec = Predictor(config)

@app.post("/ocr")
async def read_text(file: UploadFile = File(...)):
    # Kiểm tra định dạng file
    if not file.filename.lower().endswith((".jpg", ".jpeg", ".png")):
        raise HTTPException(status_code=400, detail="Chỉ hỗ trợ file ảnh (jpg, png)")

    # Tạo tên file tạm duy nhất để tránh xung đột khi nhiều người gọi API cùng lúc
    temp_name = f"temp_{uuid.uuid4()}.jpg"

    try:
        # Lưu file tạm từ request
        with open(temp_name, "wb") as buffer:
            shutil.copyfileobj(file.file, buffer)

        # Đọc ảnh bằng PIL (cho VietOCR) và OpenCV (cho PaddleOCR)
        pil_img = Image.open(temp_name).convert('RGB')
        cv_img = cv2.imread(temp_name)

        # 3. Bước 1: Dùng PaddleOCR để lấy tọa độ các khung chữ
        result = ocr_det.ocr(cv_img, cls=True)

        texts = []

        if result and result[0]:
            # Sắp xếp các line từ trên xuống dưới theo tọa độ Y
            # line[0] là tọa độ box, line[0][0][1] là giá trị Y của điểm đầu tiên
            sorted_lines = sorted(result[0], key=lambda line: line[0][0][1])

            for line in sorted_lines:
                # Lấy mảng tọa độ 4 góc [ [x1,y1], [x2,y2], [x3,y3], [x4,y4] ]
                box = line[0] 
                
                # Tính toán tọa độ bao quanh (bounding box)
                x_min = max(0, int(min([p[0] for p in box])))
                y_min = max(0, int(min([p[1] for p in box])))
                x_max = int(max([p[0] for p in box]))
                y_max = int(max([p[1] for p in box]))

                # Cắt vùng chữ ra khỏi ảnh gốc
                cropped_img = pil_img.crop((x_min, y_min, x_max, y_max))

                # 4. Bước 2: Dùng VietOCR để dự đoán nội dung trong vùng đã cắt
                recognized_text = ocr_rec.predict(cropped_img)

                if recognized_text.strip():
                    texts.append({
                        "text": recognized_text.strip(),
                        "score": 1.0 # VietOCR vgg_transformer không trả về score cụ thể
                    })

        return {
            "success": True,
            "data": texts
        }

    except Exception as e:
        print(f"DEBUG ERROR: {str(e)}")
        return {"success": False, "error": str(e)}

    finally:
        # Luôn luôn xóa file tạm sau khi xử lý xong (thành công hoặc thất bại)
        if os.path.exists(temp_name):
            os.remove(temp_name)