import CryptoJS from 'crypto-js';
import pako from 'pako';

 
// --- Base85 Encoding/Decoding ---
function createBase85(alphabet) {
    const decodeMap = new Uint8Array(256).fill(0xFF);
    for (let i = 0; i < alphabet.length; i++) {
        decodeMap[alphabet.charCodeAt(i)] = i;
    }
 
    return {
        encode(data) {
            let str = "";
            let i = 0;
            for (; i + 3 < data.length; i += 4) {
                let value = (data[i] << 24) | (data[i + 1] << 16) | (data[i + 2] << 8) | data[i + 3];
                value >>>= 0;
                const block = Array.from({ length: 5 });
                for (let j = 4; j >= 0; j--) {
                    block[j] = alphabet[value % 85];
                    value = Math.floor(value / 85);
                }
                str += block.join('');
            }
 
            const remaining = data.length - i;
            if (remaining > 0) {
                const padded = new Uint8Array(4);
                padded.set(data.subarray(i));
                let value = (padded[0] << 24) | (padded[1] << 16) | (padded[2] << 8) | padded[3];
                value >>>= 0;
                const block = Array.from({ length: 5 });
                for (let j = 4; j >= 0; j--) {
                    block[j] = alphabet[value % 85];
                    value = Math.floor(value / 85);
                }
                str += block.join('').slice(0, remaining + 1);
            }
            return str;
        },
 
        decode(str) {
            const remainder = str.length % 5;
            if (remainder === 1) throw new Error("Invalid Base85 string length.");
            const pad = remainder === 0 ? 0 : 5 - remainder;
            const paddedStr = str + "~~~~~".slice(0, pad);
            const buffer = new Uint8Array((paddedStr.length / 5) * 4);
 
            let bufferIndex = 0;
            for (let i = 0; i < paddedStr.length; i += 5) {
                let value = 0;
                for (let j = 0; j < 5; j++) {
                    const charCode = paddedStr.charCodeAt(i + j);
                    const code = decodeMap[charCode];
                    if (code === 0xFF) throw new Error(`Invalid Base85 character '${paddedStr[i + j]}'`);
                    value = value * 85 + code;
                }
                buffer[bufferIndex++] = (value >> 24) & 0xFF;
                buffer[bufferIndex++] = (value >> 16) & 0xFF;
                buffer[bufferIndex++] = (value >> 8) & 0xFF;
                buffer[bufferIndex++] = value & 0xFF;
            }
 
            const unpad = remainder === 0 ? 0 : 4 - (remainder - 1);
            return buffer.subarray(0, buffer.length - unpad);
        }
    };
}
 
const BASE85_ALPHABET = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#$%&()*+-;<=>?@^_`{|}~";
export const base85 = createBase85(BASE85_ALPHABET);
 
// --- PKCS7 Padding ---
function pkcs7Pad(data) {
    const blockSize = 16;
    const padLen = blockSize - (data.length % blockSize);
    const padded = new Uint8Array(data.length + padLen);
    padded.set(data);
    padded.fill(padLen, data.length);
    return padded;
}
 
function pkcs7Unpad(data) {
    const padLen = data[data.length - 1];
    if (padLen > 16 || padLen === 0) return data;
    return data.slice(0, data.length - padLen);
}
 
// --- Key & IV Generator ---
export function generateRandomKxi() {
    const key = crypto.getRandomValues(new Uint8Array(32));
    const iv = crypto.getRandomValues(new Uint8Array(16));
    const kxi = `${base85.encode(key)}:${base85.encode(iv)}`;
    return { kxi, key, iv };
}
 
// --- AES Encryption using CryptoJS ---
export function encryptData(plainText, keyBytes, ivBytes) {
    const compressed = pako.gzip(new TextEncoder().encode(plainText));
    const padded = pkcs7Pad(compressed);
 
    const key = CryptoJS.lib.WordArray.create(keyBytes);
    const iv = CryptoJS.lib.WordArray.create(ivBytes);
    const data = CryptoJS.lib.WordArray.create(padded);
 
    const encrypted = CryptoJS.AES.encrypt(data, key, {
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.NoPadding
    });
 
    const hex = encrypted.ciphertext.toString(CryptoJS.enc.Hex);
    const encryptedBytes = Uint8Array.from(hex.match(/.{2}/g).map(byte => parseInt(byte, 16)));
    return base85.encode(encryptedBytes);
}
 
// --- AES Decryption using CryptoJS ---
export function decryptData(cipherText, keyBytes, ivBytes) {
    const encryptedBytes = base85.decode(cipherText);
    const encryptedWords = [];
    for (let i = 0; i < encryptedBytes.length; i += 4) {
        encryptedWords.push(
            (encryptedBytes[i] << 24) |
            (encryptedBytes[i + 1] << 16) |
            (encryptedBytes[i + 2] << 8) |
            (encryptedBytes[i + 3])
        );
    }
 
    const encryptedWordArray = CryptoJS.lib.WordArray.create(encryptedWords, encryptedBytes.length);
    const key = CryptoJS.lib.WordArray.create(keyBytes);
    const iv = CryptoJS.lib.WordArray.create(ivBytes);
 
    const decrypted = CryptoJS.AES.decrypt({ ciphertext: encryptedWordArray }, key, {
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.NoPadding
    });
 
    const decryptedBytes = Uint8Array.from(decrypted.words.flatMap(w => [
        (w >>> 24) & 0xFF,
        (w >>> 16) & 0xFF,
        (w >>> 8) & 0xFF,
        w & 0xFF
    ])).slice(0, decrypted.sigBytes);
 
    const unpadded = pkcs7Unpad(decryptedBytes);
    const decompressed = pako.ungzip(unpadded);
    return new TextDecoder().decode(decompressed);
}