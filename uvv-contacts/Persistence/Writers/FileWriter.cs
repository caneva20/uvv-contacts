using System.IO;
using caneva20.Logging;

namespace caneva20.Persistence.Writers {
    public class FileWriter : IWriter {
        private readonly string _path;
        private readonly ILogger _logger;

        public FileWriter(string path, ILogger logger) {
            _path = path;
            _logger = logger;
        }

        public void Write(byte[] data) {
            // if (!File.Exists(_path)) {
            //     _logger.Error($"The path ${_path} was not found");
            //     throw new PathNotFoundException(_path);
            // }

            File.WriteAllBytes(_path, data);
        }
    }
}
