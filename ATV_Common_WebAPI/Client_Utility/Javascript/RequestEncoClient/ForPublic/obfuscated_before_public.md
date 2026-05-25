# Guide: Obfuscating Javascript for Production

This guide outlines the process for obfuscating client-side Javascript files before they are published or deployed.

## 1. Why Obfuscate?

While **minification** reduces file size, **obfuscation** intentionally makes the code difficult for humans to read and reverse-engineer. This is a crucial step to protect the intellectual property contained within the scripts and to deter tampering.

## 2. Recommended Tool

We will use `javascript-obfuscator`, a powerful and highly configurable open-source tool designed specifically for this purpose.

## 3. Prerequisites

- **Node.js and npm:** You must have Node.js installed on your system, which includes the npm package manager.

## 4. Step-by-Step Instructions

### Step 1: Install the Obfuscator

If you have not already installed it, open your terminal or command prompt and run the following command. This only needs to be done once.

```sh
npm install -g javascript-obfuscator
```

### Step 2: Navigate to the Correct Directory

In your terminal, navigate to the directory containing the Javascript files you want to protect. For our encryption utilities, this is:

```sh
cd Client_Utility/Javascript/RequestEncoClient/
```

### Step 3: Run the Obfuscation Command

To obfuscate the main utility file (`test_request_enco.js`), run the following command:

```sh
javascript-obfuscator test_request_enco.js --output enco_utils_obf.js --compact true --self-defending true
```

**Command Breakdown:**

-   `test_request_enco.js`: This is your input source file.
-   `--output enco_utils_obf.js`: This specifies the name of the new, obfuscated output file.
-   `--compact true`: This performs basic minification (removing whitespace).
-   `--self-defending true`: This is a powerful feature that makes the obfuscated code resistant to being formatted or "beautified" by other tools, making it even harder to analyze.

### Step 4: Update Your HTML to Use the New File

After the command successfully creates the `enco_utils_obf.js` file, you must update any HTML pages that use this script.

Find the `import` statement in your `<script>` tag and change the filename.

**Example:**

In `test_encrypted_api.html` and `enco_support.html`, change this line:

**From:**
```javascript
import { generateRandomKxi, encryptData, decryptData, base85 } from './test_request_enco.js';
```

**To:**
```javascript
import { generateRandomKxi, encryptData, decryptData, base85 } from './enco_utils_obfuscated.js';
```

## 5. Conclusion

Always follow this process before deploying any client-facing HTML files that rely on sensitive Javascript logic. This ensures your code is properly protected.
