using System;
using System.Collections.Generic;

namespace caneva20.CircularCollections {
    public class CircularList<T>  {
        public int Count { get; private set; }
        public Node<T> Head { get; private set; }

        public bool IsEmpty => Count == 0;
        
        public CircularList() {
            Head = null;
        }

        public CircularList(IEnumerable<T> enumerable) : this() {
            foreach (var x in enumerable) {
                Add(x);
            }
        }

        private Node<T> FindTail(Node<T> head) {
            return head.Prev == Head ? head : FindTail(head.Prev);
        }

        public Node<T> Find(Func<T, bool> keySelector) {
            var current = Head;

            do {
                if (keySelector(current.Value)) {
                    return current;
                }

                current = current.Next;
            } while (current != Head);

            return null;
        }
        
        public Node<T> Find(T value) => Find(x => x.Equals(value));

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

        public IEnumerable<T> Flatten() {
            if (Count == 0) {
                yield break;
            }

            var current = Head;

            do {
                yield return current.Value;

                current = current.Next;
            } while (current != Head);
        }
        
        public CircularList<T> OrderBy<TKey>(Func<T, TKey> keySelector) {
            var flattened = Flatten().ToArray();
            var comparer = Comparer<TKey>.Default;
            
            for (var j = 0; j <= Count - 2; j++) {
                for (var i = 0; i <= Count - 2; i++) {
                    var keyA = keySelector(flattened[i]);
                    var keyB = keySelector(flattened[i + 1]);
                    
                    if (comparer.Compare(keyA, keyB) == 1) {
                        var temp = flattened[i + 1];
                        flattened[i + 1] = flattened[i];
                        flattened[i] = temp;
                    }
                }
            }

            return new CircularList<T>(flattened);
        }
    }
}
