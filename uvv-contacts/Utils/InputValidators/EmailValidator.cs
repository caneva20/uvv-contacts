using System;
using System.Net.Mail;

namespace caneva20.Utils.InputValidators {
    public class EmailValidator : InputValidator<string> {
        protected override string GetValidation(string input) {
            try {
                new MailAddress(input);
            } catch (Exception) {
                return "Invalid email. (valid example: example@mail.com)";
            }

            return null;
        }
    }
}
