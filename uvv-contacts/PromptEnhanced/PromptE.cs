using System;
using System.Collections.Generic;
using System.Linq;
using caneva20.Utils.InputValidators;
using Sharprompt;
using Sharprompt.Validations;

namespace caneva20.PromptEnhanced {
    public class PromptE {
        internal static IEnumerable<Func<object, ValidationResult>> BuildValidators(
            IEnumerable<IInputValidator> validators,
            string defaultValue = null
        ) {
            return validators.Select(validator => BuildValidator(defaultValue, validator));
        }

        private static Func<object, ValidationResult> BuildValidator(string defaultValue, IInputValidator validator) {
            return x => {
                var value =
                    x is string && string.IsNullOrEmpty((string) x) &&
                    !string.IsNullOrEmpty(defaultValue)
                        ? defaultValue
                        : x;

                var validation = validator.GetValidation(value);

                return validation == null ? null : new ValidationResult(validation);
            };
        }
        
        public static T Input<T>(
            string message,
            string defaultValue,
            IEnumerable<InputValidator<T>> validators
        ) where T : class {
            return Prompt.Input<T>(message, defaultValue,
                BuildValidators(validators, defaultValue).ToList());
        }

        public static T Input<T>(string message, IEnumerable<InputValidator<T>> validators)
            where T : class {
            return Input(message, null, validators);
        }
        
        public static SelectBuilder<T> Select<T>(string title) {
            return new SelectBuilder<T>(title);
        }
        
        public static MenuBuilder Menu(string title) {
            return new MenuBuilder(title);
        }
    }
}
