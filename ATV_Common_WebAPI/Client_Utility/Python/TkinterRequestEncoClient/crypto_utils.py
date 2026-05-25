import os
import gzip
import json
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives import padding
from cryptography.hazmat.backends import default_backend

# --- Base85 Implementation ---
class Base85:
    ALPHABET = b'0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#$%&()*+-;<=>?@^_`{|}~'
    DECODE_MAP = {c: i for i, c in enumerate(ALPHABET)}

    @staticmethod
    def encode(data: bytes) -> str:
        n = len(data)
        padded_len = (4 - n % 4) % 4
        padded_data = data + b'\0' * padded_len
        
        encoded_chars = []
        for i in range(0, len(padded_data), 4):
            chunk = int.from_bytes(padded_data[i:i+4], 'big')
            block = [None] * 5
            for j in range(4, -1, -1):
                block[j] = Base85.ALPHABET[chunk % 85]
                chunk //= 85
            encoded_chars.extend(block)
        
        full_encoded = bytes(encoded_chars).decode('ascii')
        unpadded_len = (n // 4) * 5 + (n % 4)
        if n % 4 != 0:
            unpadded_len += 1

        return full_encoded[:unpadded_len]

    @staticmethod
    def decode(text: str) -> bytes:
        n = len(text)
        padding_needed = (5 - n % 5) % 5
        padded_text = text + "~~~~~"[:padding_needed]
        
        decoded_bytes = bytearray()
        for i in range(0, len(padded_text), 5):
            chunk_str = padded_text[i:i+5]
            value = 0
            for char_code in chunk_str:
                value = value * 85 + Base85.DECODE_MAP[ord(char_code)]
            decoded_bytes.extend(value.to_bytes(4, 'big'))
        
        unpadded_len = (n // 5) * 4
        if n % 5 != 0:
            unpadded_len += (n % 5) - 1

        return bytes(decoded_bytes[:unpadded_len])

# --- Cryptography Functions ---

def generate_kxi():
    key = os.urandom(32)
    iv = os.urandom(16)
    kxi = f"{Base85.encode(key)}:{Base85.encode(iv)}"
    return kxi, key, iv

def encrypt_payload(payload_bytes: bytes, key: bytes, iv: bytes) -> str:
    compressed = gzip.compress(payload_bytes)
    padder = padding.PKCS7(128).padder()
    padded_data = padder.update(compressed) + padder.finalize()
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=default_backend())
    encryptor = cipher.encryptor()
    encrypted_data = encryptor.update(padded_data) + encryptor.finalize()
    return Base85.encode(encrypted_data)

def decrypt_payload(encrypted_b85: str, kxi: str) -> dict:
    kxi_parts = kxi.split(':')
    key = Base85.decode(kxi_parts[0])
    iv = Base85.decode(kxi_parts[1])
    
    encrypted_data = Base85.decode(encrypted_b85)
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=default_backend())
    decryptor = cipher.decryptor()
    padded_data = decryptor.update(encrypted_data) + decryptor.finalize()
    unpadder = padding.PKCS7(128).unpadder()
    decompressed_data = unpadder.update(padded_data) + unpadder.finalize()
    final_bytes = gzip.decompress(decompressed_data)
    return json.loads(final_bytes.decode('utf-8-sig'))