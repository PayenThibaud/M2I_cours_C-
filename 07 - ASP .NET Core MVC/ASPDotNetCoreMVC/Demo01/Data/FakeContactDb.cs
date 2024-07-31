using Demo01.Models;

namespace Demo01.Data
{
    public class FakeContactDb // représente une fausse base de données(équivalent à un DbContext ou un Repository)
    {
        private List<Contact> _contacts; // équivalent de la base de données
        private int _lastId = 0; // pour faire un équivalent d'IDENTITY ou AUTO INCREMENT

        public FakeContactDb()
        {
            _contacts = new List<Contact>() // équivalent du data seed (données par défaut)
            {
                new Contact { Id = ++_lastId, FirstName = "Bob", LastName="Marley", Email="bobo@ganjamail.com", Phone="0607080910"},
                new Contact { Id = ++_lastId, FirstName = "Elvis", LastName="Presley", Email="elvis@rock.com", Phone="0607080911"},
                new Contact { Id = ++_lastId, FirstName = "Michael", LastName="Jackson", Email="mj@popking.com", Phone="0607080912"},
            };
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Contact contact)
        {
            contact.Id = ++_lastId;
            _contacts.Add(contact);
            return true; // l'ajout s'est bien passé
        }

        public bool Edit(Contact contact)
        {
            var contactFromDb = GetById(contact.Id);

            if (contactFromDb == null)
                return false;

            contactFromDb.FirstName = contact.FirstName;
            contactFromDb.LastName = contact.LastName;
            contactFromDb.Email = contact.Email;
            contactFromDb.Phone = contact.Phone;

            return true;
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);

            if (contact == null)
                return false;

            _contacts.Remove(contact);

            return true;
        }
    }
}
