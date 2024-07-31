using Exercice04.Models;
using System.Linq.Expressions;

namespace Exercice04.Repositories
{
    // cette interface représent les interractions de CRUD
    // que l'on pourra faire ensuite de différentes manières (FakeDb, EFCore, MongoDb, ...)
    public interface IRepository<TEntity> // s'adapte à plusieurs entités
    {
        bool Add(TEntity animal);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        bool Update(TEntity animal);
        bool Delete(int id);
    }
}