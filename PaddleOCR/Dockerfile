FROM paddlepaddle/paddle:2.6.2

WORKDIR /app

RUN pip install --upgrade pip

# 🔥 QUAN TRỌNG: khóa numpy < 2
RUN pip install numpy==1.26.4

# 🔥 cài opencv đúng bản headless (tránh conflict GUI)
RUN pip install opencv-python-headless==4.8.1.78

# 🔥 cài đúng version ổn định của paddleocr
RUN pip install paddleocr==2.7.0.3

# API deps
RUN pip install fastapi uvicorn python-multipart

COPY . .

CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]