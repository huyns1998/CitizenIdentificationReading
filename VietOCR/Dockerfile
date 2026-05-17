FROM paddlepaddle/paddle:2.6.2

WORKDIR /app

# 1. Nâng cấp pip và các công cụ cơ bản
RUN pip install --no-cache-dir --upgrade pip setuptools wheel

# 2. CÀI ĐẶT CÁC THƯ VIỆN CỐT LÕI (Fix lỗi ANTIALIAS và Numpy 2.0)
# Khóa Pillow < 10.0.0 để tương thích với VietOCR
RUN pip install --no-cache-dir \
    "Pillow<10.0.0" \
    "numpy<2.0" \
    -i https://pypi.tuna.tsinghua.edu.cn/simple

# 3. CÀI ĐẶT TORCH (Tách layer + Retries cực cao để chống đứt mạng)
RUN pip install --no-cache-dir \
    --default-timeout=3000 \
    --retries 100 \
    torch --index-url https://download.pytorch.org/whl/cpu

# 4. CÀI ĐẶT TORCHVISION
RUN pip install --no-cache-dir \
    --default-timeout=3000 \
    --retries 100 \
    torchvision --index-url https://download.pytorch.org/whl/cpu

# 5. CÀI ĐẶT CÁC THƯ VIỆN AI & API (Dùng Mirror Châu Á cho tốc độ nhanh)
RUN pip install --no-cache-dir --default-timeout=1000 \
    paddleocr==2.7.0.3 \
    vietocr \
    opencv-python-headless==4.8.1.78 \
    fastapi uvicorn python-multipart \
    -i https://pypi.tuna.tsinghua.edu.cn/simple

COPY . .

# Tạo thư mục cache cho trọng số của VietOCR
RUN mkdir -p /root/.cache/torch/hub/checkpoints/

EXPOSE 8000

CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]