using System;
using System.Collections.Generic;
using caneva20.Menus;

namespace caneva20.PromptEnhanced {
    public class MenuBuilder {
        private readonly List<IMenuAction> _actions = new List<IMenuAction>();
        private readonly string _title;

        public MenuBuilder(string title) {
            _title = title;
        }

        private void ShowMenu(string title, IEnumerable<IMenuAction> actions) {
            var builder = PromptE.Select<Action>(title);

            foreach (var action in actions) {
                builder.Option(action.Title, action.Run);
            }

            builder.Show()();
        }

        public MenuBuilder Action(IMenuAction action) {
            _actions.Add(action);

            return this;
        }
        
        public MenuBuilder Action(string title, Action action) {
            _actions.Add(new GenericMenuAction(title, action));

            return this;
        }

        public void Show() => ShowMenu(_title, _actions);
    }
}
