FROM python:3

WORKDIR /usr/src/app

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt

COPY /main.py .
COPY /db_model.py .

CMD ["flask", "--app", "main", "run", "--host=0.0.0.0"]