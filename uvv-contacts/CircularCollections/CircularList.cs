namespace caneva20.CircularCollections {
    public class CircularList<T>  {
        public int Count { get; private set; }
        public Node<T> Head { get; private set; }

        public bool IsEmpty => Count == 0;
        
        public CircularList() {
            Head = null;
        }

        private Node<T> FindTail(Node<T> head) {
            return head.Prev == Head ? head : FindTail(head.Prev);
        }

        public Node<T> Find(T value) {
            var current = Head;

            do {
                if (current.Value.Equals(value)) {
                    return current;
                }

                current = current.Next;
            } while (current != Head);

            return null;
        }

        public void Add(T value) {
            var newNode = new Node<T>(value);

            if (Head == null) {
                Head = newNode;
                Head.Prev = newNode;
                Head.Next = newNode;
            } else {
                var tail = FindTail(Head);

                newNode.Next = Head.Next;
                newNode.Prev = Head;
                Head.Next = newNode;
                tail.Prev = newNode;

                Head = newNode;
            }

            Count++;
        }

        public void Remove(T value) {
            var node = Find(value);

            if (node == null) {
                return;
            }

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            Count--;
        }

        public void Clear() {
            while (Count != 0) {
                Remove(Head.Value);
            }
        }
    }
}
