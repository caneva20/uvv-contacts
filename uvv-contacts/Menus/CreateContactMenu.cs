using caneva20.Models;
using caneva20.PromptEnhanced;
using caneva20.Utils;
using caneva20.Utils.InputValidators;

namespace caneva20.Menus {
    public static class CreateContactMenu  {
        public static Contact Show(Contact contact = null) {
            contact ??= new Contact();

            Update(contact);

            return contact;
        }

        private static void Update(Contact contact) {
            var firstName = PromptE.Input("First name", contact.FirstName,
                new[] {new MinLengthValidator("First name", 3),});

            var middleName = PromptE.Input("Middle name", contact.MiddleName, new[] {
                new MinLengthValidator("Middle name", 3, true),
            });

            var lastName = PromptE.Input("Last name", contact.LastName, new[] {
                new MinLengthValidator("Last name", 3),
            });

            var email = PromptE.Input("Email", contact.Email, new InputValidator<string>[] {
                new MinLengthValidator("Email name", 3),
                new EmailValidator(),
            });

            var cellphone = PromptE.Input("Cellphone number", contact.CellphoneNumber,
                new InputValidator<string>[] {
                    new MinLengthValidator("Cellphone number", 3),
                    new CellphoneValidator(),
                });

            contact.FirstName = firstName;
            contact.MiddleName = middleName;
            contact.LastName = lastName;
            contact.Email = email;
            contact.CellphoneNumber = CellphoneUtils.Parse(cellphone);
        }
    }

    public class UpdateContactAction : IMenuAction {
        public string Title => "Update";

        private readonly ContactBook _book;
        private readonly Contact _contact;

        public UpdateContactAction(ContactBook book, Contact contact) {
            _contact = contact;
            _book = book;
        }

        public void Run() {
            CreateContactMenu.Show(_contact);

            _book.Update(_contact);
        }
    }
}
