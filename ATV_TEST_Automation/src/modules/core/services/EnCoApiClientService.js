import { base85, encryptData, decryptData, generateRandomKxi } from './EnCoCrytoService.js';
import axios from 'axios';

export class EnCoApiClientService {
    #baseUrl;

    /**
     * @param {string} baseUrl The base URL of the API (e.g., http://localhost:5067)
     */
    constructor(baseUrl) {
        this.#baseUrl = baseUrl.endsWith('/') ? baseUrl.slice(0, -1) : baseUrl;
    }

    async #callApi(endpoint, payload) {
        try {
            // 1. Prepare request data
            const payloadString = JSON.stringify(payload);

            // 2. Generate crypto materials and encrypt
            const { kxi, key, iv } = generateRandomKxi();
            const encryptedBase85 = encryptData(payloadString, key, iv);

            // 3. Make the request
            const response = await axios.post(`${this.#baseUrl}${endpoint}`, encryptedBase85, {
                headers: {
                    'Content-Type': 'text/plain',
                    'kxi': kxi
                }
            });

            // 4. Process the response
            const resKxi = response.headers['kxi'];
            if (!resKxi) throw new Error("Response missing 'kxi' header.");

            const [resKeyB85, resIvB85] = resKxi.split(':');
            const resKeyBytes = base85.decode(resKeyB85);
            const resIvBytes = base85.decode(resIvB85);

            const decryptedResString = decryptData(response.data, resKeyBytes, resIvBytes);
            const finalResponse = JSON.parse(decryptedResString);

            if (finalResponse.code !== 200) {
                throw new Error(`API returned error code ${finalResponse.code}: ${finalResponse.message}`);
            }

            return finalResponse.body;

        } catch (error) {
            console.error("API Client Error:", error);
            throw error;
        }
    }

    /**
     * Calls the encrypted stored procedure endpoint.
     * @param {string} spName The name of the stored procedure.
     * @param {object} spQuery A dictionary of parameters for the SP.
     * @param {string} [dbKey="CIMitar"] The database key to use.
     * @param {boolean} [logSave=false] Whether to save the call to the log.
     * @returns {Promise<object>} The 'body' of the API response.
     */
    async callSp(spName, spQuery, dbKey = "CIMitar", logSave = false) {
        const endpoint = "/Common/Data_Method/DB_EnCo/Call_SP";
        const payload = { dbKey, spName, spQuery, logSave };
        return this.#callApi(endpoint, payload);
    }

    /**
     * Calls the encrypted SQL command endpoint.
     * @param {string} scQuery The SQL query string to execute.
     * @param {string} [dbKey="CIMitar"] The database key to use.
     * @param {boolean} [logSave=false] Whether to save the call to the log.
     * @returns {Promise<object>} The 'body' of the API response.
     */
    async callSc(scQuery, dbKey = "CIMitar", logSave = false) {
        const endpoint = "/Common/Data_Method/DB_EnCo/Call_SC";
        const payload = { dbKey, scQuery, logSave };
        return this.#callApi(endpoint, payload);
    }

    async #callApiForFileUpload(endpoint, file, metadata) {
        try {
            // 1. Prepare metadata
            const metadataString = JSON.stringify(metadata);

            // 2. Generate crypto materials and encrypt metadata
            const { kxi, key, iv } = generateRandomKxi();
            const encryptedMetadataB85 = encryptData(metadataString, key, iv);

            // 3. Prepare FormData
            const formData = new FormData();
            formData.append('file', file);

            // 4. Make the request
            const response = await axios.post(`${this.#baseUrl}${endpoint}`, formData, {
                headers: {
                    'kxi': kxi,
                    'Set-File-Info': encryptedMetadataB85
                }
            });

            // 5. Process the encrypted JSON response
            const resKxi = response.headers['kxi'];
            if (!resKxi) throw new Error("Response missing 'kxi' header.");

            const [resKeyB85, resIvB85] = resKxi.split(':');
            const resKeyBytes = base85.decode(resKeyB85);
            const resIvBytes = base85.decode(resIvB85);

            const decryptedResString = decryptData(response.data, resKeyBytes, resIvBytes);
            const finalResponse = JSON.parse(decryptedResString);

            if (finalResponse.code !== 200) {
                throw new Error(`API returned error code ${finalResponse.code}: ${finalResponse.message}`);
            }

            return finalResponse.body;

        } catch (error) {
            console.error("API File Upload Error:", error);
            throw error;
        }
    }

    async #callApiForFileDownload(endpoint, payload) {
        try {
            // 1. Encrypt request payload
            const payloadString = JSON.stringify(payload);
            const { kxi, key, iv } = generateRandomKxi();
            const encryptedBase85 = encryptData(payloadString, key, iv);

            // 2. Make the request
            const response = await axios.post(`${this.#baseUrl}${endpoint}`, encryptedBase85, {
                headers: {
                    'Content-Type': 'text/plain',
                    'kxi': kxi
                },
                responseType: 'blob'
            });

            // 3. Process file response
            const contentDisposition = response.headers['content-disposition'];
            let filename = 'downloaded-file';
            if (contentDisposition) {
                const match = contentDisposition.match(/filename="?([^"]+)"?/);
                if (match && match[1]) filename = match[1];
            }

            return { filename, blob: response.data };

        } catch (error) {
            console.error("API File Download Error:", error);
            throw error;
        }
    }

    /**
     * Performs an encrypted file operation.
     * @param {string} command The file operation command (e.g., 'list', 'move').
     * @param {object} operation The parameters for the operation - refer API docs for more details.
     * @returns {Promise<object>} The 'body' of the API response.
     */
    async callFileOps(command, operation) {
        const endpoint = "/Common/File_Method/File_Ops";
        const payload = { command, operation };
        return this.#callApi(endpoint, payload);
    }

    /**
     * Uploads a file with encrypted metadata.
     * @param {File} file The file object to upload.
     * @param {object} metadata The metadata for the file.
     * @returns {Promise<object>} The 'body' of the API response.
     */
    async uploadFile(file, metadata) {
        const endpoint = "/Common/File_Method/Set";
        // Automatically add fileName and fileSize to metadata if not present
        const fullMetadata = {
            fileName: file.name,
            fileSize: file.size,
            ...metadata,
        };
        return this.#callApiForFileUpload(endpoint, file, fullMetadata);
    }

    /**
     * Downloads a file using an encrypted request.
     * @param {object} payload The file configuration object
     * @param {string} payload.filePath The path of the file to download.
     * @param {string} payload.fileName The filname of the file to download.
     * @returns {Promise<{filename: string, blob: Blob}>} An object containing the filename and blob.
     */
    async downloadFile(payload) {
        const endpoint = "/Common/File_Method/Get";
        return this.#callApiForFileDownload(endpoint, payload);
    }

    /**
     * Sends an encrypted email with optional attachments.
     * @param {object} payload The email configuration object
     * @param {string} payload.mailPriority Email priority level
     * @param {string} payload.sender The sender's email address
     * @param {string} payload.subject The email subject line
     * @param {string} payload.body The email body content
     * @param {string[]} payload.toMailList Array of recipient email addresses
     * @param {string[]} [payload.ccMailList] Array of CC recipient email addresses
     * @param {string[]} [payload.bccMailList] Array of BCC recipient email addresses
     * @param {object[]} [payload.attachmentList] Array of file attachments
     * @param {string} payload.attachmentList.base64File Base64 encoded file content
     * @param {string} payload.attachmentList.fileName Original filename
     * @param {string} payload.attachmentList.mimeType File MIME type
     * Optional fields:
     * @param {object} payload.smtpConfig SMTP server configuration
     * @param {string} payload.smtpConfig.smtpDomain SMTP server domain
     * @param {string} payload.smtpConfig.smtpAccountName SMTP account name
     * @param {string} payload.smtpConfig.smtpPassword SMTP account password
     * @param {number} payload.smtpConfig.smtpPort SMTP server port
     * @returns {Promise<object>} The 'body' of the API response
     */
    async sendEmail(payload) {
        const endpoint = "/Common/Email_EnCo/Send_Email";
        return this.#callApi(endpoint, payload);
    }
}
