using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using caneva20.Models;
using caneva20.Persistence;

namespace caneva20 {
    public class ContactBook {
        private readonly IList<Contact> _contacts = new List<Contact>();
        private readonly IPersister<IEnumerable<Contact>> _persister;
        
        public IReadOnlyCollection<Contact> List => new ReadOnlyCollection<Contact>(_contacts);

        public ContactBook(IPersister<IEnumerable<Contact>> persister) {
            _persister = persister;

            Load();
        }

        private void Save() {
            _persister.Save(_contacts);
        }

        private void Load() {
            _contacts.Clear();

            var contacts = _persister.Read();

            if (contacts == null) {
                return;
            }

            foreach (var contact in contacts) {
                _contacts.Add(contact);
            }
        }

        public void Add(Contact contact) {
            _contacts.Add(contact);

            Save();
        }

        public void Remove(Contact contact) {
            _contacts.Remove(contact);

            Save();
        }

        public void Update(Contact contact) {
            var found = _contacts.FirstOrDefault(x => x.Id == contact.Id);
            
            if (found != null) {
                _contacts.Remove(found);
                _contacts.Add(contact);
            }
            
            Save();
        }
    }
}
