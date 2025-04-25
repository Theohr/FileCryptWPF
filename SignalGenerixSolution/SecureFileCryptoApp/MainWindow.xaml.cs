using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace SecureFileCryptoApp
{
    public partial class MainWindow : Window
    {
        private readonly CryptoService _cryptoService;
        private readonly Logger _logger;

        // Constructor initializes the UI, crypto service, and logger
        public MainWindow()
        {
            InitializeComponent();
            _cryptoService = new CryptoService(); // Service for handling encryption/decryption
            _logger = new Logger(); // Logger for tracking actions and errors
            _logger.LogMessage += (msg) => LogTextBox.AppendText(msg + Environment.NewLine); // Subscribe to log messages for UI display
        }

        // Handles the Browse button click to select a file
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Standard Windows file dialog
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName; // Display selected file path
                StatusTextBlock.Text = "File selected successfully."; // Update status
                _logger.Log("File selected: " + openFileDialog.FileName); // Log the action
            }
        }

        // Handles the Encrypt button click to initiate file encryption
        private async void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate file selection
                if (string.IsNullOrEmpty(FilePathTextBox.Text))
                {
                    StatusTextBlock.Text = "Please select a file.";
                    _logger.Log("Error: No file selected for encryption");
                    return;
                }

                // Validate password input
                if (string.IsNullOrEmpty(PasswordBox.Password))
                {
                    StatusTextBlock.Text = "Please enter a password.";
                    _logger.Log("Error: No password provided for encryption");
                    return;
                }

                StatusTextBlock.Text = "Encrypting..."; // Show progress
                await _cryptoService.EncryptFileAsync(FilePathTextBox.Text, PasswordBox.Password); // Perform encryption
                StatusTextBlock.Text = "Encryption successful! File saved in Encrypt folder."; // Update status
                _logger.Log("Encryption completed for: " + FilePathTextBox.Text); // Log success
            }
            catch (Exception ex)
            {
                // Handle and display any errors during encryption
                StatusTextBlock.Text = $"Encryption failed: {ex.Message}";
                _logger.Log($"Encryption error: {ex.Message}");
            }
        }

        // Handles the Decrypt button click to initiate file decryption
        private async void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate file selection
                if (string.IsNullOrEmpty(FilePathTextBox.Text))
                {
                    StatusTextBlock.Text = "Please select a file.";
                    _logger.Log("Error: No file selected for decryption");
                    return;
                }

                // Validate password input
                if (string.IsNullOrEmpty(PasswordBox.Password))
                {
                    StatusTextBlock.Text = "Please enter a password.";
                    _logger.Log("Error: No password provided for decryption");
                    return;
                }

                StatusTextBlock.Text = "Decrypting..."; // Show progress
                await _cryptoService.DecryptFileAsync(FilePathTextBox.Text, PasswordBox.Password); // Perform decryption
                StatusTextBlock.Text = "Decryption successful! File saved in Decrypt folder."; // Update status
                _logger.Log("Decryption completed for: " + FilePathTextBox.Text); // Log success
            }
            catch (Exception ex)
            {
                // Handle and display any errors during decryption
                StatusTextBlock.Text = $"Decryption failed: {ex.Message}";
                _logger.Log($"Decryption error: {ex.Message}");
            }
        }
    }
}