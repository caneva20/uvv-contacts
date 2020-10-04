namespace caneva20.Utils.InputValidators {
    public class MinLengthValidator : InputValidator<string> {
        private readonly string _propertyName;
        private readonly int _minLength;
        private readonly bool _allowEmpty;

        public MinLengthValidator(string propertyName, int minLength, bool allowEmpty = false) {
            _propertyName = propertyName;
            _minLength = minLength;
            _allowEmpty = allowEmpty;
        }

        protected override string GetValidation(string input) {
            if (_allowEmpty) {
                return null;
            }

            if (input.Length < _minLength) {
                return $"{_propertyName} must be at least {_minLength} long!";
            }

            return null;
        }
    }
}
