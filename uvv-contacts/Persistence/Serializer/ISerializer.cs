namespace caneva20.Persistence.Serializer {
    public interface ISerializer<T> {
        string Serialize(T data);

        T Deserialize(string serializedData);
    }
}
