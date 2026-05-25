# Email Encryption Service API

This document outlines the usage of the secure email sending endpoint. The service leverages the `EncryptionCompressionMiddleware` to ensure that all communication is encrypted.

## 1. Email Service Workflow

The endpoint follows a standard encrypted request/response pattern. The client encrypts the request payload, and the server sends back an encrypted response.

```mermaid
sequenceDiagram
    participant Client
    participant Middleware
    participant Endpoint
    participant EmailService

    Note over Client, EmailService: Encrypted Email Flow (/Send_Email)
    Client->>Server: POST text/plain
Header kxi: [key:iv]
Body: [encrypted_request]
    Server->>Middleware: Request arrives
    Middleware->>Middleware: Decrypts request body to JSON
    Middleware->>Endpoint: Calls /Common/Email_EnCo/Send_Email
    Endpoint->>EmailService: Calls SendEmail(request) with deserialized model
    EmailService-->>Endpoint: Returns a result object (e.g., success status)
    Endpoint-->>Middleware: Returns the result as JSON
    Middleware->>Middleware: Encrypts the JSON response
    Middleware-->>Client: Returns encrypted JSON payload
```

## 2. `POST /Common/Email_EnCo/Send_Email`

Securely sends an email. The request and response are both encrypted.

*   **Request Type**: `text/plain`
*   **Headers**:
    *   `kxi`: A Base85 encoded string containing the encryption key and IV, separated by a colon (e.g., `key:iv`). This is used to encrypt the request body.
*   **Request Body (before encryption)**:
    A JSON object representing the email to be sent, based on the `EmailRequestModel`.
    ```json
    {
      "To": ["recipient1@example.com", "recipient2@example.com"],
      "Cc": ["cc_recipient@example.com"],
      "Bcc": ["bcc_recipient@example.com"],
      "Subject": "This is a test email",
      "Body": "<h1>Hello World!</h1><p>This is the body of the email.</p>",
      "IsBodyHtml": true,
      "Attachments": [
        "\\server\share\docs\report.pdf",
        "\\server\share\images\logo.png"
      ]
    }
    ```
    *   `To` (array of strings, required): List of primary recipients' email addresses.
    *   `Cc` (array of strings, optional): List of carbon copy recipients.
    *   `Bcc` (array of strings, optional): List of blind carbon copy recipients.
    *   `Subject` (string, required): The subject line of the email.
    *   `Body` (string, required): The content of the email. Can be plain text or HTML.
    *   `IsBodyHtml` (bool, optional): Set to `true` if the `Body` contains HTML markup. Defaults to `false`.
    *   `Attachments` (array of strings, optional): A list of full network paths to files that should be attached to the email.

*   **Success Response (decrypted)**:
    A JSON object confirming that the email was successfully queued for sending.
    ```json
    {
      "code": 200,
      "message": "OK",
      "body": {
        "success": true,
        "message": "Email sent successfully."
      }
    }
    ```
*   **Error Response (decrypted)**:
    If an error occurs (e.g., invalid email address, SMTP server issue), the response will indicate the failure.
    ```json
    {
      "code": 500,
      "message": "Internal Server Error: Failed to send email. The specified SMTP server is not reachable.",
      "body": null
    }
    ```

