using System.Text.RegularExpressions;

namespace caneva20.Utils {
    public static class CellphoneUtils {
        private const string CELLPHONE_REGEX = @"^\+?(\d{2}) ?\(?(\d{2})\)? ?(\d{4})[ -]?(\d{5})$";

        public static bool IsValid(string cellphone) {
            return Regex.IsMatch(cellphone, CELLPHONE_REGEX);
        }

        public static string Parse(string cellphone) {
            return Regex.Replace(cellphone, CELLPHONE_REGEX, "+$1 ($2) $3-$4");
        }
    }
}
