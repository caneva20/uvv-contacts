using System.Collections.Generic;
using Autofac;
using caneva20.Logging;
using caneva20.Menus;
using caneva20.Models;
using caneva20.Persistence;
using caneva20.Persistence.Readers;
using caneva20.Persistence.Serializer;
using caneva20.Persistence.Writers;

namespace caneva20 {
    class Program {
        private const string CONTACTS_BOOK_PATH = "C:/Users/Jesus/Desktop/out/book.json";

        private static void Main(string[] args) {
            var container = BuildDIContainer();
            
            var book = container.Resolve<ContactBook>();

            MainMenu.Show(book);
        }

        private static IContainer BuildDIContainer() {
            var diBuilder = new ContainerBuilder();

            diBuilder.RegisterType<Logger>().As<ILogger>();

            diBuilder.RegisterType<FileWriter>()
               .As<IWriter>()
               .WithParameter(new TypedParameter(typeof(string), CONTACTS_BOOK_PATH));

            diBuilder.RegisterType<FileReader>()
               .As<IReader>()
               .WithParameter(new TypedParameter(typeof(string), CONTACTS_BOOK_PATH));

            diBuilder.RegisterType<JsonSerializer<IEnumerable<Contact>>>()
               .As<ISerializer<IEnumerable<Contact>>>();
            diBuilder.RegisterType<Persister<IEnumerable<Contact>>>()
               .As<IPersister<IEnumerable<Contact>>>();

            diBuilder.RegisterType<ContactBook>();

            return diBuilder.Build();
        }
    }
}
