from flask import Flask, request
import json

app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def index():
    if request.method == 'GET':
        name = request.args.get('name')
        sex = request.args.get('sex')
        age = request.args.get('age')
    elif request.method == 'POST':
        name = request.form['name']
        sex = request.form['sex']
        age = request.form['age']
    data = { 'name': name, 'sex': sex, 'age': age }
    return json.dumps(data)

if __name__ == '__main__':
    app.run()
