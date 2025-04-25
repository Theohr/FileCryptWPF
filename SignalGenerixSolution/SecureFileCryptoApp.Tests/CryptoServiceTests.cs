using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureFileCryptoApp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SecureFileCryptoApp.Tests
{
    [TestClass]
    public class CryptoServiceTests
    {
        private readonly CryptoService _cryptoService = new CryptoService(); // Service under test
        private readonly string _testFilePath = Path.Combine(Path.GetTempPath(), "test.txt"); // Temporary test file
        private readonly string _password = "TestPassword123"; // Test password

        // Setup method creates a test file before each test
        [TestInitialize]
        public void Setup()
        {
            File.WriteAllText(_testFilePath, "This is a test file for encryption."); // Create test file with known content
        }

        // Cleanup method removes test files after each test
        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath); // Remove test file

            string encryptedFile = _testFilePath + ".enc";
            if (File.Exists(encryptedFile))
                File.Delete(encryptedFile); // Remove encrypted file
        }

        // Tests successful encryption and file creation
        [TestMethod]
        public async Task EncryptFileAsync_ValidInput_CreatesEncryptedFile()
        {
            // Act
            await _cryptoService.EncryptFileAsync(_testFilePath, _password); // Encrypt test file

            // Assert
            string encryptFolder = Path.Combine(Path.GetDirectoryName(_testFilePath), "Encrypt"); // Expected output folder
            string encryptedFilePath = Path.Combine(encryptFolder, Path.GetFileName(_testFilePath) + ".enc"); // Expected output file
            Assert.IsTrue(File.Exists(encryptedFilePath)); // Verify encrypted file exists
        }

        // Tests successful decryption and content restoration
        [TestMethod]
        public async Task DecryptFileAsync_ValidInput_RestoresOriginalContent()
        {
            // Arrange
            await _cryptoService.EncryptFileAsync(_testFilePath, _password); // First encrypt the file
            string encryptFolder = Path.Combine(Path.GetDirectoryName(_testFilePath), "Encrypt"); // Encrypted file folder
            string encryptedFilePath = Path.Combine(encryptFolder, Path.GetFileName(_testFilePath) + ".enc"); // Encrypted file path

            // Act
            await _cryptoService.DecryptFileAsync(encryptedFilePath, _password); // Decrypt the file

            // Assert
            string decryptFolder = Path.Combine(Path.GetDirectoryName(encryptedFilePath), "Decrypt"); // Expected output folder
            string decryptedFilePath = Path.Combine(decryptFolder, Path.GetFileName(_testFilePath)); // Expected output file
            string decryptedContent = File.ReadAllText(decryptedFilePath); // Read decrypted content
            Assert.AreEqual("This is a test file for encryption.", decryptedContent); // Verify content matches original
        }
    }
}