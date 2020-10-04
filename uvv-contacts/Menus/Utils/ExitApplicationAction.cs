using System;

namespace caneva20.Menus.Utils {
    public class ExitApplicationAction : IMenuAction {
        public string Title => "[Exit]";

        public void Run() {
            Environment.Exit(0);
        }
    }
}
