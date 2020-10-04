namespace caneva20.Utils.InputValidators {
    public interface IInputValidator {
        string GetValidation(object input);
    }

    public abstract class InputValidator<T> : IInputValidator where T : class {
        public string GetValidation(object input) => GetValidation((T) input);

        protected abstract string GetValidation(T input);
    }
}
