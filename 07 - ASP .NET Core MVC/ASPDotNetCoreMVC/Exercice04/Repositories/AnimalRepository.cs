using Exercice04.Data;
using Exercice04.Models;
using System.Linq.Expressions;

namespace Exercice04.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private ApplicationDbContext _dbContext;
        public AnimalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public bool Add(Animal animal)
        {
            var addedObj = _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        // READ
        public Animal? GetById(int id)
        {
            return _dbContext.Animals.Find(id);
        }
        public Animal? Get(Expression<Func<Animal, bool>> predicate)
        {
            return _dbContext.Animals.FirstOrDefault(predicate);
        }
        public List<Animal> GetAll()
        {
            return _dbContext.Animals.ToList();
        }
        public List<Animal> GetAll(Expression<Func<Animal, bool>> predicate)
        {
            return _dbContext.Animals.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Animal animal)
        {
            var animalFromDb = GetById(animal.Id);

            if (animalFromDb == null)
                return false;

            if (animalFromDb.FirstName != animal.FirstName)
                animalFromDb.FirstName = animal.FirstName;
            if (animalFromDb.Age != animal.Age)
                animalFromDb.Age = animal.Age;
            if (animalFromDb.Species != animal.Species)
                animalFromDb.Species = animal.Species;
            if (animalFromDb.PicturePath != animal.PicturePath)
                animalFromDb.PicturePath = animal.PicturePath;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var animal = GetById(id);
            if (animal == null)
                return false;
            _dbContext.Animals.Remove(animal);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
