using System;
using System.Collections.Generic;
using caneva20.CircularCollections;
using caneva20.Models;
using caneva20.Persistence;

namespace caneva20 {
    public class ContactBook {
        private readonly CircularList<Contact> _contacts = new CircularList<Contact>();
        private readonly IPersister<IEnumerable<Contact>> _persister;

        public ContactBook(IPersister<IEnumerable<Contact>> persister) {
            _persister = persister;

            Load();
        }

        private void Save() {
            _persister.Save(_contacts.Flatten());
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
            var found = _contacts.Find(x => x.Id == contact.Id).Value;

            if (found != null) {
                _contacts.Remove(found);
                _contacts.Add(contact);
            }

            Save();
        }

        public CircularList<Contact> OrderBy<TKey>(Func<Contact, TKey> keySelector) {
            return _contacts.OrderBy(keySelector);
        }
    }
}
