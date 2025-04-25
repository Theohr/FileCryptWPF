using System;
using System.IO;

namespace SecureFileCryptoApp
{
    public class Logger
    {
        private readonly string _logFilePath; // Path to the log file
        public event Action<string> LogMessage; // Event to notify UI of new log messages

        // Constructor initializes the log file path
        public Logger()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"); // Log file in application directory
        }

        // Logs a message to both file and UI
        public void Log(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}"; // Format log entry with timestamp
            LogMessage?.Invoke(logEntry); // Notify UI subscribers

            try
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine); // Append to log file
            }
            catch (Exception ex)
            {
                // Log file write failure to UI only (avoid recursive logging)
                LogMessage?.Invoke($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}