import requests
import json
import os

# Import shared cryptography functions
import crypto_utils
import config

# --- Configuration ---
# API_BASE_URL is now managed by config.py

# --- API Call Functions ---

def upload_file(local_file_path: str, metadata: dict):
    if not os.path.exists(local_file_path):
        raise FileNotFoundError(f"File not found at '{local_file_path}'")

    metadata_bytes = json.dumps(metadata).encode('utf-8')
    req_kxi, req_key, req_iv = crypto_utils.generate_kxi()
    encrypted_metadata = crypto_utils.encrypt_payload(metadata_bytes, req_key, req_iv)
    
    headers = {
        'kxi': req_kxi,
        'Set-File-Info': encrypted_metadata
    }

    with open(local_file_path, 'rb') as f:
        files = {'file': (metadata["FileName"], f)}
        response = requests.post(f"{config.API_BASE_URL}/Common/File_Method/Set", headers=headers, files=files)

    response.raise_for_status()
    
    response_json = crypto_utils.decrypt_payload(response.text, response.headers['kxi'])
    if response_json.get('code', 200) >= 300:
        raise Exception(f"API Error {response_json.get('code')}: {response_json.get('message')}")

    return response_json.get('body')

def download_file(remote_file_path: str, local_save_path: str):
    payload = {"filePath": remote_file_path}
    payload_bytes = json.dumps(payload).encode('utf-8')
    req_kxi, req_key, req_iv = crypto_utils.generate_kxi()
    encrypted_payload = crypto_utils.encrypt_payload(payload_bytes, req_key, req_iv)
    
    headers = {
        'kxi': req_kxi,
        'Content-Type': 'text/plain'
    }

    with requests.post(f"{config.API_BASE_URL}/Common/File_Method/Get", headers=headers, data=encrypted_payload, stream=True) as response:
        response.raise_for_status()
        with open(local_save_path, 'wb') as f:
            for chunk in response.iter_content(chunk_size=8192):
                f.write(chunk)

def file_operation(payload: dict):
    payload_bytes = json.dumps(payload).encode('utf-8')
    req_kxi, req_key, req_iv = crypto_utils.generate_kxi()
    encrypted_payload = crypto_utils.encrypt_payload(payload_bytes, req_key, req_iv)
    
    headers = {
        'kxi': req_kxi,
        'Content-Type': 'text/plain'
    }

    response = requests.post(f"{config.API_BASE_URL}/Common/File_Method/File_Ops", headers=headers, data=encrypted_payload)
    response.raise_for_status()

    response_json = crypto_utils.decrypt_payload(response.text, response.headers['kxi'])
    if response_json.get('code', 200) >= 300:
        raise Exception(f"API Error {response_json.get('code')}: {response_json.get('message')}")

    return response_json.get('body')