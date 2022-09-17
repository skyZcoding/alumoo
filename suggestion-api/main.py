import numpy as np
import peewee
from flask import Flask
from flask import request

app = Flask(__name__)

@app.route("/<int:vID>/<int:pg>")
def serve(vID, pg):
    return f"<p>Serving information for user with id {vID}</p>"