# Secure File Encryption/Decryption Application

## Overview
This is a WPF desktop application for securely encrypting and decrypting files using the AES algorithm. The application provides a user-friendly interface with file browsing, encryption/decryption capabilities, password protection, and comprehensive logging.

## Prerequisites
- .NET Framework 4.8 or later
- Visual Studio 2022 or later
- MSTest for running unit tests

## Building the Application
Clone the repository:
```bash
git clone https://github.com/piacovou/SecureFileCryptoApp.git
```
Open SecureFileCryptoApp.sln in Visual Studio.
Build the solution (Debug or Release configuration).

## Running the Application
Run the application from Visual Studio (F5) or execute the compiled executable from bin/Debug or bin/Release.
The application will open a window with the following features:
	Browse: Select a file to encrypt/decrypt.
	Password: Enter the encryption/decryption password.
	Encrypt: Encrypt the selected file (saves to Encrypt folder with .enc extension).
	Decrypt: Decrypt the selected file (saves to Decrypt folder).
	Status: Displays operation status.
	Log: Shows real-time log messages.

## Logging
Logs are saved to log.txt in the application directory.
Logs include timestamps and details of operations/errors.

## Unit Tests
Open the Test Explorer in Visual Studio.
Run the tests in SecureFileCryptoApp.Tests project.
Tests verify:
	Successful file encryption
	Successful decryption with correct content restoration

## Security Notes
Uses AES-256 with CBC mode and PKCS7 padding
Password-based key derivation with PBKDF2 (1000 iterations)
Random salt and IV for each encryption
Secure file handling with proper disposal of cryptographic resources

## Troubleshooting
Ensure the selected file exists and is accessible.
Verify the password matches for decryption.
Check log.txt for detailed error messages if operations fail.


# Notes
- The application uses AES-256 with CBC mode and PKCS7 padding for secure encryption.
- PBKDF2 with 1000 iterations is used for key derivation from the password.
- Random salt and IV are generated for each encryption operation.
- The application creates `Encrypt` and `Decrypt` folders in the same directory as the input file.
- Logging is implemented with both file output and UI display.
- Unit tests verify encryption and decryption functionality.
- The repository should be created with access granted to p.iacovou@signalgenerix.com.
- All sensitive cryptographic resources are properly disposed of using `using` statements.
