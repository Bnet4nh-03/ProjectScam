import requests
import json

# Import shared cryptography functions
import crypto_utils
import config

# --- Configuration ---
# API_BASE_URL is now managed by config.py

# --- API Call Functions ---

def call_sc(payload: dict):
    """Calls the encrypted SQL Command (SC) endpoint."""
    payload_bytes = json.dumps(payload).encode('utf-8')
    req_kxi, req_key, req_iv = crypto_utils.generate_kxi()
    encrypted_payload = crypto_utils.encrypt_payload(payload_bytes, req_key, req_iv)
    
    headers = {
        'kxi': req_kxi,
        'Content-Type': 'text/plain'
    }

    response = requests.post(f"{config.API_BASE_URL}/Common/Data_Method/DB_EnCo/Call_SC", headers=headers, data=encrypted_payload)
    response.raise_for_status()

    response_json = crypto_utils.decrypt_payload(response.text, response.headers['kxi'])
    if response_json.get('code', 200) >= 300:
        raise Exception(f"API Error {response_json.get('code')}: {response_json.get('message')}")

    return response_json.get('body')

def call_sp(payload: dict):
    """Calls the encrypted Stored Procedure (SP) endpoint."""
    payload_bytes = json.dumps(payload).encode('utf-8')
    req_kxi, req_key, req_iv = crypto_utils.generate_kxi()
    encrypted_payload = crypto_utils.encrypt_payload(payload_bytes, req_key, req_iv)
    
    headers = {
        'kxi': req_kxi,
        'Content-Type': 'text/plain'
    }

    response = requests.post(f"{config.API_BASE_URL}/Common/Data_Method/DB_EnCo/Call_SP", headers=headers, data=encrypted_payload)
    response.raise_for_status()

    response_json = crypto_utils.decrypt_payload(response.text, response.headers['kxi'])
    if response_json.get('code', 200) >= 300:
        raise Exception(f"API Error {response_json.get('code')}: {response_json.get('message')}")

    return response_json.get('body')