using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileCryptoApp
{
    public class CryptoService
    {
        private const int KeySize = 256; // AES-256 key size in bits
        private const int BlockSize = 128; // AES block size in bits
        private const int Iterations = 1000; // PBKDF2 iteration count for key derivation

        // Encrypts a file using AES-256 with the provided password
        public async Task EncryptFileAsync(string inputFilePath, string password)
        {
            // Validate input file existence
            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException("Input file not found.");

            // Create Encrypt folder if it doesn't exist
            string encryptFolder = Path.Combine(Path.GetDirectoryName(inputFilePath), "Encrypt");
            Directory.CreateDirectory(encryptFolder);
            string outputFilePath = Path.Combine(encryptFolder, Path.GetFileName(inputFilePath) + ".enc"); // Append .enc extension

            byte[] salt = GenerateRandomSalt(); // Generate random salt for PBKDF2
            byte[] iv = GenerateRandomIV(); // Generate random initialization vector

            using (Aes aes = Aes.Create()) // Create AES instance
            {
                aes.KeySize = KeySize; // Set key size to 256 bits
                aes.BlockSize = BlockSize; // Set block size to 128 bits
                aes.Mode = CipherMode.CBC; // Use Cipher Block Chaining mode
                aes.Padding = PaddingMode.PKCS7; // Use PKCS7 padding for variable-length data

                using (var keyDerivation = new Rfc2898DeriveBytes(password, salt, Iterations)) // Derive key from password
                {
                    aes.Key = keyDerivation.GetBytes(KeySize / 8); // Generate 32-byte key
                    aes.IV = iv; // Set initialization vector

                    using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create)) // Create output file
                    {
                        // Write salt and IV to the beginning of the encrypted file
                        await fsOutput.WriteAsync(salt, 0, salt.Length);
                        await fsOutput.WriteAsync(iv, 0, iv.Length);

                        using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write)) // Create encryption stream
                        {
                            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open)) // Open input file
                            {
                                await fsInput.CopyToAsync(cs); // Encrypt and write to output
                            }
                        }
                    }
                }
            }
        }

        // Decrypts a file using AES-256 with the provided password
        public async Task DecryptFileAsync(string inputFilePath, string password)
        {
            // Validate input file existence
            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException("Input file not found.");

            // Create Decrypt folder if it doesn't exist
            string decryptFolder = Path.Combine(Path.GetDirectoryName(inputFilePath), "Decrypt");
            Directory.CreateDirectory(decryptFolder);
            string outputFilePath = Path.Combine(decryptFolder, Path.GetFileNameWithoutExtension(inputFilePath)); // Remove .enc extension

            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open)) // Open encrypted file
            {
                byte[] salt = new byte[8]; // Buffer for salt
                byte[] iv = new byte[16]; // Buffer for IV

                // Read salt and IV from the beginning of the file
                await fsInput.ReadAsync(salt, 0, salt.Length);
                await fsInput.ReadAsync(iv, 0, iv.Length);

                using (Aes aes = Aes.Create()) // Create AES instance
                {
                    aes.KeySize = KeySize; // Set key size to 256 bits
                    aes.BlockSize = BlockSize; // Set block size to 128 bits
                    aes.Mode = CipherMode.CBC; // Use Cipher Block Chaining mode
                    aes.Padding = PaddingMode.PKCS7; // Use PKCS7 padding

                    using (var keyDerivation = new Rfc2898DeriveBytes(password, salt, Iterations)) // Derive key from password
                    {
                        aes.Key = keyDerivation.GetBytes(KeySize / 8); // Generate 32-byte key
                        aes.IV = iv; // Set initialization vector

                        using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create)) // Create output file
                        {
                            using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateDecryptor(), CryptoStreamMode.Write)) // Create decryption stream
                            {
                                await fsInput.CopyToAsync(cs); // Decrypt and write to output
                            }
                        }
                    }
                }
            }
        }

        // Generates a random salt for PBKDF2 key derivation
        private static byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[8]; // 8-byte salt
            using (var rng = RandomNumberGenerator.Create()) // Cryptographically secure RNG
            {
                rng.GetBytes(salt); // Fill salt with random bytes
            }
            return salt;
        }

        // Generates a random initialization vector for AES
        private static byte[] GenerateRandomIV()
        {
            byte[] iv = new byte[16]; // 16-byte IV for AES-128/256
            using (var rng = RandomNumberGenerator.Create()) // Cryptographically secure RNG
            {
                rng.GetBytes(iv); // Fill IV with random bytes
            }
            return iv;
        }
    }
}