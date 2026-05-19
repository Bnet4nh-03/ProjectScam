import requests

url = "http://10.201.12.31:8004/Common/BCrypt_Hash"

data_list = [
    "260046",
    "260083",
    "240181",
    "260289",
    "260067",
    "240124",
    "250618",
    "240140",
    "240666",
    "240599"
]

results = {}

for item in data_list:
    try:
        response = requests.get(url, params={"text": item})
        if response.status_code == 200:
            results[item] = response.text
        else:
            results[item] = "ERROR"
    except Exception as e:
        results[item] = str(e)

# print result
for k, v in results.items():
    print(f"{k} -> {v}")