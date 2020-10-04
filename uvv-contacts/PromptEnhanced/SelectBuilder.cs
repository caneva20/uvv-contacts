using System.Collections.Generic;
using System.Linq;
using caneva20.Menus.Utils;
using Sharprompt;

namespace caneva20.PromptEnhanced {
    public class SelectBuilder<T> {
        private readonly List<ActionEntry> _actions = new List<ActionEntry>();
        private readonly string _title;

        public SelectBuilder(string title) {
            _title = title;
        }

        public SelectBuilder<T> Option(string option, T value) {
            _actions.Add(new ActionEntry(option, value));

            return this;
        }

        public T Show() {
            var options = _actions.Select(x => new SelectOption<T>(x.Title, x.Value));

            return Prompt.Select(_title, options).Value;
        }
        
        private class ActionEntry {
            public string Title { get; set; }
            public T Value { get; set; }

            public ActionEntry(string title, T value) {
                Title = title;
                Value = value;
            }
        }
    }
}
