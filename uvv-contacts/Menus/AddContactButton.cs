namespace caneva20.Menus {
    internal class AddContactButton : IMenuAction {
        private readonly ContactBook _book;

        public string Title => "Add new contact";

        public AddContactButton(ContactBook book) {
            _book = book;
        }

        public void Run() {
            var contact = CreateContactMenu.Show();

            if (contact == null) {
                return;
            }

            _book.Add(contact);
        }
    }
}
