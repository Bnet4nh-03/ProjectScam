import os
import base64
import gzip
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives.padding import PKCS7
from cryptography.hazmat.backends import default_backend

"""
This module provides cryptographic functions equivalent to the JavaScript EnCoCrytoService.js.
It requires the 'cryptography' library.
You can install it using pip:
pip install cryptography
"""

def generate_random_kxi():
    """
    Generates a random 32-byte key and a 16-byte IV.
    Returns a dictionary containing the key, IV, and a 'kxi' string,
    which is the base85-encoded key and IV joined by a colon.
    """
    key = os.urandom(32)
    iv = os.urandom(16)
    kxi = f"{base64.b85encode(key).decode('ascii')}:{base64.b85encode(iv).decode('ascii')}"
    return {"kxi": kxi, "key": key, "iv": iv}

def encrypt_data(plain_text: str, key: bytes, iv: bytes) -> str:
    """
    Encrypts a string using AES-256-CBC, after gzipping and PKCS7 padding.
    The final output is base85 encoded.

    :param plain_text: The string to encrypt.
    :param key: A 32-byte encryption key.
    :param iv: A 16-byte initialization vector.
    :return: A base85 encoded encrypted string.
    """
    # 1. Gzip compress the UTF-8 encoded plaintext
    compressed = gzip.compress(plain_text.encode('utf-8'))

    # 2. Apply PKCS7 padding
    padder = PKCS7(algorithms.AES.block_size).padder()
    padded_data = padder.update(compressed) + padder.finalize()

    # 3. Encrypt using AES-CBC
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=default_backend())
    encryptor = cipher.encryptor()
    encrypted_data = encryptor.update(padded_data) + encryptor.finalize()

    # 4. Base85 encode the result
    return base64.b85encode(encrypted_data).decode('ascii')

def decrypt_data(cipher_text: str, key: bytes, iv: bytes) -> str:
    """
    Decrypts a base85 encoded string that was encrypted with AES-256-CBC.
    It performs base85 decoding, decryption, PKCS7 unpadding, and gzip decompression.

    :param cipher_text: The base85 encoded string to decrypt.
    :param key: The 32-byte encryption key used for encryption.
    :param iv: The 16-byte initialization vector used for encryption.
    :return: The original decrypted and decompressed string.
    """
    # 1. Base85 decode the ciphertext
    encrypted_data = base64.b85decode(cipher_text)

    # 2. Decrypt using AES-CBC
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=default_backend())
    decryptor = cipher.decryptor()
    decrypted_padded_data = decryptor.update(encrypted_data) + decryptor.finalize()

    # 3. Remove PKCS7 padding
    unpadder = PKCS7(algorithms.AES.block_size).unpadder()
    unpadded_data = unpadder.update(decrypted_padded_data) + unpadder.finalize()

    # 4. Gzip decompress the data
    decompressed_data = gzip.decompress(unpadded_data)

    # 5. Decode from UTF-8 to string
    return decompressed_data.decode('utf-8-sig')
