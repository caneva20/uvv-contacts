using System;
using caneva20.Models;
using caneva20.PromptEnhanced;

namespace caneva20.Menus {
    public static class OrderingMethodMenu {
        public static Func<Contact, object> Show() {
            return PromptE.Select<Func<Contact, object>>("Ordering method")
               .Option("First name", x => x.FirstName)
               .Option("Middle name", x => x.MiddleName)
               .Option("Last name", x => x.LastName)
               .Option("Email", x => x.Email)
               .Option("Cellphone number", x => x.CellphoneNumber)
               .Option("Cancel", null)
               .Show();
        }
    }
}
