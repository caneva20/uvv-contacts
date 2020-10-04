namespace caneva20.Menus.Utils {
    public class SelectOption<T> {
        public string Title { get; }
        public T Value { get; }

        public SelectOption(string title, T value) {
            Title = title;
            Value = value;
        }

        public override string ToString() {
            return Title;
        }
    }
}
