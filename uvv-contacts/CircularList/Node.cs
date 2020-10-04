namespace caneva20.CircularList {
    public class Node<T> {
        public T Value { get; }

        public Node<T> Next { get; internal set; }
        public Node<T> Prev { get; internal set; }

        public Node(T value) {
            Value = value;
        }

        public Node() : this(default) { }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
