import cv2
import numpy as np
from fastapi import FastAPI, UploadFile, File

app = FastAPI()

# Load WeChat QR detector
# Lưu ý: Đảm bảo các file model nằm đúng đường dẫn
detector = cv2.wechat_qrcode_WeChatQRCode(
    "models/detect.prototxt",
    "models/detect.caffemodel",
    "models/sr.prototxt",
    "models/sr.caffemodel"
)

def parse_cccd_qr(qr_string: str):
    # Dữ liệu CCCD thường phân tách bằng dấu '|'
    parts = qr_string.split('|')
    if len(parts) >= 6:
        return {
            "cccd_number": parts[0],
            "old_id": parts[1] if parts[1] else None,
            "full_name": parts[2],
            "dob": parts[3],
            "gender": parts[4],
            "address": parts[5],
            "issue_date": parts[6] if len(parts) > 6 else None # Thêm ngày cấp nếu có
        }
    return None

@app.post("/scan-qr/scan-cccd")
async def scan_qr(file: UploadFile = File(...)):
    contents = await file.read()
    img_array = np.frombuffer(contents, np.uint8)
    img = cv2.imdecode(img_array, cv2.IMREAD_COLOR)

    # WeChat QR decode trả về list các text tìm thấy
    decoded_texts, _ = detector.detectAndDecode(img)

    cccd_data = None

    for qr_data in decoded_texts:
        if qr_data and "|" in qr_data:
            parsed = parse_cccd_qr(qr_data)
            if parsed:
                cccd_data = parsed
                break  # Dừng lại khi tìm thấy thẻ CCCD đầu tiên

    if not cccd_data:
        return {
            "success": False,
            "message": "Không tìm thấy dữ liệu CCCD hợp lệ"
        }

    return {
        "success": True,
        "data": cccd_data
    }