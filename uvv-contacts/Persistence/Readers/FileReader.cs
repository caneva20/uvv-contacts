using System.IO;
using caneva20.Logging;

namespace caneva20.Persistence.Readers {
    public class FileReader : IReader {
        private readonly string _path;
        private readonly ILogger _logger;

        public FileReader(string path, ILogger logger) {
            _path = path;
            _logger = logger;
        }

        public byte[] Read() {
            if (!File.Exists(_path)) {
                _logger.Warning($"Path {_path} does not exist!");
                
                return new byte[0];
            }

            return File.ReadAllBytes(_path);
        }
    }
}
