using System;

namespace caneva20.Menus {
    public interface IMenuAction {
        string Title { get; }

        void Run();
    }

    public class GenericMenuAction : IMenuAction {
        public string Title { get; }
        
        private readonly Action _action;

        public GenericMenuAction(string title, Action action) {
            Title = title;
            _action = action;
        }

        public void Run() => _action?.Invoke();
    }
}
