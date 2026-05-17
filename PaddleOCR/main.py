from fastapi import FastAPI, UploadFile, File, HTTPException
from paddleocr import PaddleOCR
import shutil
import uuid
import os
import math
import cv2
import numpy as np

app = FastAPI()

# 1. Nâng cấp lên PP-OCRv4 và tắt log để tăng tốc
ocr = PaddleOCR(
    use_angle_cls=True,
    lang='vi',
    use_gpu=False,
    ocr_version='PP-OCRv4',
    show_log=False
)

def preprocess_image(image_path):
    """
    Tiền xử lý ảnh để làm nổi bật các dấu tiếng Việt
    """
    img = cv2.imread(image_path)
    if img is None:
        return
    
    # Chuyển sang ảnh xám
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    
    # Tăng độ tương phản (Rescale intensity)
    # Giúp các dấu thanh (sắc, huyền...) đậm hơn so với nền thẻ
    alpha = 1.5 # Độ tương phản (1.0-3.0)
    beta = 0    # Độ sáng (0-100)
    adjusted = cv2.convertScaleAbs(gray, alpha=alpha, beta=beta)
    
    # Ghi đè lại file tạm để PaddleOCR đọc bản đã xử lý
    cv2.imwrite(image_path, adjusted)

@app.post("/ocr")
async def read_text(file: UploadFile = File(...)):
    if not file.filename.lower().endswith((".jpg", ".jpeg", ".png")):
        raise HTTPException(status_code=400, detail="Chỉ hỗ trợ file ảnh (jpg, png)")

    temp_name = f"temp_{uuid.uuid4()}.jpg"

    try:
        with open(temp_name, "wb") as buffer:
            shutil.copyfileobj(file.file, buffer)

        # 2. Thực hiện làm nét ảnh trước khi đưa vào OCR
        preprocess_image(temp_name)

        # 3. Chạy OCR với tham số det_db_thresh thấp hơn để không bỏ sót nét chữ mờ
        result = ocr.ocr(temp_name, cls=True)
        
        texts = []
        
        if result and result[0]:
            # Sắp xếp lại các dòng theo tọa độ Y (từ trên xuống dưới) 
            # để output đúng thứ tự dòng trên CCCD
            lines = sorted(result[0], key=lambda x: x[0][0][1])

            for item in lines:
                text = item[1][0]
                score = item[1][1]

                if not math.isfinite(score):
                    score = 0.0

                texts.append({
                    "text": text,
                    "score": round(float(score), 4)
                })

        return {
            "success": True,
            "data": texts
        }

    except Exception as e:
        return {"success": False, "error": str(e)}

    finally:
        if os.path.exists(temp_name):
            os.remove(temp_name)