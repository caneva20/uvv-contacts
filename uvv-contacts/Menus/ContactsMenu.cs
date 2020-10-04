using caneva20.PromptEnhanced;

namespace caneva20.Menus {
    public static class ContactsMenu {
        public static void Show(ContactBook book) {
            var contact = ContactSelectorMenu.Show(book);

            if (contact == null) {
                return;
            }

            PromptE.Menu($"[name: {contact.DisplayName} | email: {contact.Email} | cell: {contact.CellphoneNumber}]")
               .Action(new UpdateContactAction(book, contact))
               .Action("Delete", () => book.Remove(contact))
               .Action("[Cancel]", null)
               .Show();
        }
    }
}
