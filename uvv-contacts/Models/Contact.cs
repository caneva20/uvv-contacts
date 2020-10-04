using System;
using Newtonsoft.Json;

namespace caneva20.Models {
    public class Contact {
        [JsonProperty] public Guid Id { get; private set; } = Guid.NewGuid();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string Email { get; set; }
        public string CellphoneNumber { get; set; }

        public string DisplayName =>
            $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? "" : $" {MiddleName}")} {LastName}";
    }
}
