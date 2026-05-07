import httpx
import json
import os
import base64
import logging
from enco_crypto import generate_random_kxi, encrypt_data, decrypt_data

"""
This module provides an asynchronous Python client for the EnCo API.
It requires the 'httpx' library and the 'enco_crypto.py' module.

You can install httpx using pip:
pip install httpx
"""

class EnCoApiClientAsync:
    def __init__(self, base_url: str, logger=None):
        """
        Initializes the async API client.
        :param base_url: The base URL of the API (e.g., http://localhost:5067)
        :param logger: An optional logger instance.
        """
        self.base_url = base_url.rstrip('/')
        self.logger = logger or logging.getLogger(__name__)

    async def _call_api(self, endpoint: str, payload: dict) -> dict:
        """Internal method to handle generic encrypted API calls."""
        try:
            payload_string = json.dumps(payload)

            crypto_materials = generate_random_kxi()
            kxi = crypto_materials['kxi']
            encrypted_base85 = encrypt_data(payload_string, crypto_materials['key'], crypto_materials['iv'])

            headers = {'Content-Type': 'text/plain', 'kxi': kxi}
            async with httpx.AsyncClient() as client:
                response = await client.post(f"{self.base_url}{endpoint}", headers=headers, data=encrypted_base85)
                response.raise_for_status()

            res_kxi = response.headers.get('kxi')
            if not res_kxi:
                raise ValueError("Response missing 'kxi' header.")

            res_key_b85, res_iv_b85 = res_kxi.split(':')
            res_key_bytes = base64.b85decode(res_key_b85)
            res_iv_bytes = base64.b85decode(res_iv_b85)

            decrypted_res_string = decrypt_data(response.text, res_key_bytes, res_iv_bytes)
            final_response = json.loads(decrypted_res_string)

            if final_response.get('code') != 200:
                raise Exception(f"API returned error code {final_response.get('code')}: {final_response.get('message')}")

            return final_response.get('body')

        except httpx.HTTPStatusError as e:
            self.logger.error(f"API Client HTTP Error: {e}")
            raise
        except Exception as e:
            self.logger.error(f"API Client Error: {e}")
            raise

    async def call_sp(self, sp_name: str, sp_query: dict, db_key: str = "CIMitar", log_save: bool = False) -> dict:
        """Calls the encrypted stored procedure endpoint."""
        endpoint = "/Common/Data_Method/DB_EnCo/Call_SP"
        payload = {"dbKey": db_key, "spName": sp_name, "spQuery": sp_query, "logSave": log_save}
        return await self._call_api(endpoint, payload)

    async def call_sc(self, sc_query: str, db_key: str = "CIMitar", log_save: bool = False) -> dict:
        """Calls the encrypted SQL command endpoint."""
        endpoint = "/Common/Data_Method/DB_EnCo/Call_SC"
        payload = {"dbKey": db_key, "scQuery": sc_query, "logSave": log_save}
        return await self._call_api(endpoint, payload)

    async def _call_api_for_file_upload(self, endpoint: str, file_path: str, metadata: dict) -> dict:
        """Internal method to handle encrypted file uploads."""
        try:
            metadata_string = json.dumps(metadata)
            crypto_materials = generate_random_kxi()
            encrypted_metadata_b85 = encrypt_data(metadata_string, crypto_materials['key'], crypto_materials['iv'])

            headers = {'kxi': crypto_materials['kxi'], 'Set-File-Info': encrypted_metadata_b85}

            # Reading the file synchronously here for simplicity.
            # For very large files in a high-concurrency application, consider 'aiofiles'.
            with open(file_path, 'rb') as f:
                files = {'file': (os.path.basename(file_path), f.read())}

            async with httpx.AsyncClient() as client:
                response = await client.post(f"{self.base_url}{endpoint}", headers=headers, files=files)
                response.raise_for_status()

            res_kxi = response.headers.get('kxi')
            if not res_kxi:
                raise ValueError("Response missing 'kxi' header.")

            res_key_b85, res_iv_b85 = res_kxi.split(':')
            res_key_bytes = base64.b85decode(res_key_b85)
            res_iv_bytes = base64.b85decode(res_iv_b85)

            decrypted_res_string = decrypt_data(response.text, res_key_bytes, res_iv_bytes)
            final_response = json.loads(decrypted_res_string)

            if final_response.get('code') != 200:
                raise Exception(f"API returned error code {final_response.get('code')}: {final_response.get('message')}")

            return final_response.get('body')

        except httpx.HTTPStatusError as e:
            self.logger.error(f"API File Upload HTTP Error: {e}")
            raise
        except Exception as e:
            self.logger.error(f"API File Upload Error: {e}")
            raise

    async def _call_api_for_file_download(self, endpoint: str, payload: dict) -> dict:
        """Internal method to handle encrypted file downloads."""
        try:
            payload_string = json.dumps(payload)
            crypto_materials = generate_random_kxi()
            encrypted_base85 = encrypt_data(payload_string, crypto_materials['key'], crypto_materials['iv'])

            headers = {'Content-Type': 'text/plain', 'kxi': crypto_materials['kxi']}
            async with httpx.AsyncClient() as client:
                response = await client.post(f"{self.base_url}{endpoint}", headers=headers, data=encrypted_base85)
                response.raise_for_status()

            content_disposition = response.headers.get('content-disposition', '')
            import re
            match = re.search(r'filename="?([^"]+)"?', content_disposition)
            filename = match.group(1) if match else 'downloaded-file'

            return {"filename": filename, "content": response.content}

        except httpx.HTTPStatusError as e:
            self.logger.error(f"API File Download HTTP Error: {e}")
            raise
        except Exception as e:
            self.logger.error(f"API File Download Error: {e}")
            raise

    async def call_file_ops(self, command: str, operation: dict) -> dict:
        """Performs an encrypted file operation."""
        endpoint = "/Common/File_Method/File_Ops"
        payload = {"command": command, "operation": operation}
        return await self._call_api(endpoint, payload)

    async def upload_file(self, file_path: str, metadata: dict) -> dict:
        """Uploads a file with encrypted metadata."""
        endpoint = "/Common/File_Method/Set"
        full_metadata = {
            "fileName": os.path.basename(file_path),
            "fileSize": os.path.getsize(file_path),
            **metadata,
        }
        return await self._call_api_for_file_upload(endpoint, file_path, full_metadata)

    async def download_file(self, file_path: str) -> dict:
        """Downloads a file using an encrypted request."""
        endpoint = "/Common/File_Method/Get"
        payload = {"filePath": file_path}
        return await self._call_api_for_file_download(endpoint, payload)

    async def send_email(self, payload: dict) -> dict:
        """Sends an email with an encrypted payload."""
        endpoint = "/Common/Email_EnCo/Send_Email"
        return await self._call_api(endpoint, payload)
