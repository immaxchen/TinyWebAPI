import http.client
from urllib.parse import urlencode

host = 'localhost:5000'
method = 'POST'
route = '/'
payload = urlencode( { 'name': 'Max', 'sex': 'M', 'age': 30 } )
headers = { 'Content-Type': 'application/x-www-form-urlencoded' }

conn = http.client.HTTPConnection(host)
conn.request(method, route, payload, headers)
response = conn.getresponse()

print(response.status, response.reason)
print(response.read().decode())

## Other Customization Examples:
# import json
# payload = json.dumps( YOUR-DATA-HERE )
# headers = { 'Content-Type': 'application/json', 'Authorization': 'Basic YOUR-KEY-HERE' }
# conn = http.client.HTTPSConnection( YOUR-HOST-HERE )
