using caneva20.Menus.Utils;
using caneva20.PromptEnhanced;

namespace caneva20.Menus {
    public static class MainMenu {
        public static void Show(ContactBook book) {
            while (true) {
                PromptE.Menu("[UVV Contacts] Pick an option")
                   .Action(new AddContactButton(book))
                   .Action(new ExitApplicationAction())
                   .Show();
            }
            
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
