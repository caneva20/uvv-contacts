using System.Text;
using caneva20.Persistence.Readers;
using caneva20.Persistence.Serializer;
using caneva20.Persistence.Writers;

namespace caneva20.Persistence {
    public class Persister<T> : IPersister<T> {
        private readonly IWriter _writer;
        private readonly IReader _reader;
        private readonly ISerializer<T> _serializer;
        
        public Persister(IWriter writer, IReader reader, ISerializer<T> serializer) {
            _writer = writer;
            _reader = reader;
            _serializer = serializer;
        }

        public void Save(T data) {
            var serializedData = _serializer.Serialize(data);

            var bytes = Encoding.UTF8.GetBytes(serializedData);
            
            _writer.Write(bytes);
        }

        public T Read() {
            var bytes = _reader.Read();

            if (bytes.Length <= 0) {
                return default;
            }

            var serializedData = Encoding.UTF8.GetString(bytes);

            return _serializer.Deserialize(serializedData);
        }
    }
}
