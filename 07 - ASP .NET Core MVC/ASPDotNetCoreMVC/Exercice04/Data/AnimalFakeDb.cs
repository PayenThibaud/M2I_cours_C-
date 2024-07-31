using Exercice04.Models;
using Exercice04.Repositories;
using System.Linq.Expressions;

namespace Exercice04.Data
{
    public class AnimalFakeDb : IRepository<Animal>
    {
        private List<Animal> _animal; // équivalent de la base de données
        private int _lastId = 0; // pour faire un équivalent d'IDENTITY ou AUTO INCREMENT
        public AnimalFakeDb()
        {
            _animal = new List<Animal>() // Data Seed
            {
                new Animal { Id = ++_lastId, FirstName = "Bob", Age=4, Species="Chat"},
                new Animal { Id = ++_lastId, FirstName = "Elvis", Age=11, Species="Zèbre"},
                new Animal { Id = ++_lastId, FirstName = "Michael",Age=22, Species="Cheval"}
            };
        }

        public List<Animal> GetAll()
        {
            return _animal;
        }

        public Animal? GetById(int id)
        {
            return _animal.FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Animal pets)
        {
            pets.Id = ++_lastId;
            _animal.Add(pets);
            return true; // l'ajout s'est bien passé
        }

        public bool Update(Animal pets)
        {
            var petsFromDb = GetById(pets.Id);

            if (petsFromDb == null)
                return false;

            petsFromDb.FirstName = pets.FirstName;
            petsFromDb.Age = pets.Age;
            petsFromDb.Species = pets.Species;

            return true;
        }

        public bool Delete(int id)
        {
            var pets = GetById(id);

            if (pets == null)
                return false;

            _animal.Remove(pets);

            return true;
        }

        public Animal? Get(Expression<Func<Animal, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAll(Expression<Func<Animal, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
