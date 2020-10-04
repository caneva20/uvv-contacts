using caneva20.Models;
using caneva20.PromptEnhanced;

namespace caneva20.Menus {
    public static class ContactSelectorMenu  {
        public static Contact Show(ContactBook book) {
            var orderingField = OrderingMethodMenu.Show();
            
            if (orderingField == null) {
                return null;
            }

            var contacts = book.OrderBy(orderingField);

            var builder = PromptE.Select<Contact>("Select contact");

            foreach (var contact in contacts) {
                builder.Option(contact.DisplayName, contact);
            }

            builder.Option("[Cancel]", null);

            return builder.Show();
        }
    }
}
