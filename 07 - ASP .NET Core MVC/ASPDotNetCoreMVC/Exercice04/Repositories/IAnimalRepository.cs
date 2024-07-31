using Exercice04.Models;
using System.Linq.Expressions;

namespace Exercice04.Repositories
{
    public interface IAnimalRepository // uniquement pour l'entité Animal
    {
        bool Add(Animal animal);
        Animal? Get(Expression<Func<Animal, bool>> predicate);
        List<Animal> GetAll();
        List<Animal> GetAll(Expression<Func<Animal, bool>> predicate);
        Animal? GetById(int id);
        bool Update(Animal animal);
        bool Delete(int id);
    }
}