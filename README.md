Secure File Encryption/Decryption Application
Introduction
This Windows Presentation Foundation (WPF) desktop application, built with C#, provides secure file encryption and decryption using the AES-256 algorithm. It features a user-friendly interface, robust error handling, logging, and unit tests to ensure reliability and security.
Features

Secure Encryption/Decryption: Utilizes AES-256 with CBC mode and PKCS7 padding.
User Interface: Intuitive WPF GUI with file browsing, password input, and real-time status updates.
File Management: Saves encrypted files with .enc extension in an Encrypt folder and decrypted files in a Decrypt folder.
Logging: Records actions and errors in log.txt and displays them in the UI.
Error Handling: Manages invalid inputs, file access issues, and incorrect passwords.
Unit Tests: Validates encryption and decryption functionality using MSTest.

Project Structure
SecureFileCryptoApp/
├── SecureFileCryptoApp/               # Main application project
│   ├── MainWindow.xaml                # WPF UI layout
│   ├── MainWindow.xaml.cs             # UI logic and event handlers
│   ├── CryptoService.cs               # Encryption/decryption logic
│   ├── Logger.cs                      # Logging functionality
│   ├── App.config                     # Application configuration
│   └── Properties/                    # Project properties
├── SecureFileCryptoApp.Tests/         # Unit test project
│   ├── CryptoServiceTests.cs          # Unit tests for CryptoService
│   └── Properties/                    # Test project properties
├── README.md                          # Project documentation
└── SecureFileCryptoApp.sln            # Solution file

Prerequisites

Operating System: Windows 10 or later
.NET Framework: 4.8 or later
IDE: Visual Studio 2022 or later (Community, Professional, or Enterprise)
Testing Framework: MSTest (included with Visual Studio)
Dependencies: No external NuGet packages required

Installation

Create a GitHub Repository:

Set up a new repository on GitHub.
Grant collaborator access to p.iacovou@signalgenerix.com.


Clone the Repository:
git clone <your-repository-url>
cd SecureFileCryptoApp


Open the Solution:

Launch Visual Studio.
Open SecureFileCryptoApp.sln.


Build the Solution:

Select Debug or Release configuration.
Click Build > Build Solution or press Ctrl+Shift+B.



Usage

Run the Application:

Press F5 in Visual Studio to start in Debug mode, or
Run SecureFileCryptoApp.exe from bin/Debug or bin/Release.


Interface Guide:

Browse Button: Select a file using the Windows file dialog.
Password Field: Enter a secure password for encryption/decryption.
Encrypt Button: Encrypts the selected file and saves it to the Encrypt folder with a .enc extension.
Decrypt Button: Decrypts a .enc file and saves it to the Decrypt folder.
Status Display: Shows operation progress and results.
Log Window: Displays real-time logs of actions and errors.



Running Unit Tests

Open Test Explorer in Visual Studio (Test > Test Explorer).
Build the SecureFileCryptoApp.Tests project.
Click Run All in Test Explorer to execute tests.
Tests verify:
Successful encryption creates a .enc file.
Decryption restores the original file content.



Security Details

Encryption Algorithm: AES-256 with Cipher Block Chaining (CBC) mode.
Padding: PKCS7 for handling variable-length data.
Key Derivation: PBKDF2 with 1000 iterations and an 8-byte random salt.
Initialization Vector: 16-byte random IV per encryption.
Resource Management: Uses using statements to securely dispose of cryptographic resources.
Password Security: User-provided password is used directly for key derivation; no storage of passwords.

Logging

Log File: Saved as log.txt in the application directory.
Format: YYYY-MM-DD HH:mm:ss - Message.
UI Integration: Logs are displayed in real-time in the application window.
Error Handling: File write failures are reported in the UI.

Troubleshooting

"File Not Found" Error: Ensure the selected file exists and is accessible.
Decryption Failure: Verify the password matches the one used for encryption.
Permission Denied: Run the application as Administrator if file access is restricted.
Log File Issues: Ensure log.txt is writable; delete and restart if corrupted.
Build Errors: Confirm .NET Framework 4.8 is installed and targeted.
Test Failures: Check write permissions in the temporary directory (Path.GetTempPath()).

Contributing
To contribute:

Fork the repository.
Create a feature branch (git checkout -b feature/new-feature).
Commit changes (git commit -m "Add new feature").
Push to the branch (git push origin feature/new-feature).
Open a pull request.

Repository Access

Create a GitHub repository for the project.
Add p.iacovou@signalgenerix.com as a collaborator with write access.
Push the code to the repository before sharing.

License
This project is licensed under the MIT License. See the LICENSE file for details (create a LICENSE file if needed).
Contact
For issues or questions, contact the repository owner or email p.iacovou@signalgenerix.com.
Notes

The application uses AES-256 with CBC mode and PKCS7 padding for secure encryption.
PBKDF2 with 1000 iterations is used for key derivation from the password.
Random salt and IV are generated for each encryption operation.
The application creates Encrypt and Decrypt folders in the same directory as the input file.
Logging is implemented with both file output and UI display.

