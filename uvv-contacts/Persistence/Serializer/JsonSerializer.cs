using Newtonsoft.Json;

namespace caneva20.Persistence.Serializer {
    public class JsonSerializer<T> : ISerializer<T> {
        public string Serialize(T data) {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public T Deserialize(string serializedData) {
            return JsonConvert.DeserializeObject<T>(serializedData);
        }
    }
}
