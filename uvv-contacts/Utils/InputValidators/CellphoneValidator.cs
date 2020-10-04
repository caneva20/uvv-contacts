namespace caneva20.Utils.InputValidators {
    public class CellphoneValidator : InputValidator<string> {
        protected override string GetValidation(string input) {
            if (!CellphoneUtils.IsValid(input)) {
                return "Invalid cellphone number! (valid example +12 23 4455-66779)";
            }

            return null;
        }
    }
}
