namespace caneva20.Persistence {
    public interface IPersister<T> {
        void Save(T data);

        T Read();
    }
}
