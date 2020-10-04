using System;

namespace caneva20.Logging {
    public class Logger : ILogger {
        public void Debug(string message) {
            Console.WriteLine($"[DEBUG] {message}");
        }

        public void Info(string message) {
            Console.WriteLine($" [INFO] {message}");
        }

        public void Warning(string message) {
            Console.WriteLine($" [WARN] {message}");
        }

        public void Error(string message) {
            Console.WriteLine($"[ERROR] {message}");
        }
    }
}
