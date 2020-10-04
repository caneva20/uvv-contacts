namespace caneva20.Logging {
    public interface ILogger {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}
