import requests

# url = 'http://localhost:5000/'
url = 'http://localhost:18525/'

params = { 'name': 'Max', 'sex': 'M', 'age': 30 }
response = requests.get(url, params=params)
print(response.text)

data = { 'name': 'Max', 'sex': 'M', 'age': 30 }
response = requests.post(url, data=data)
print(response.text)
