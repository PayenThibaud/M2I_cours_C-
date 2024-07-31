using System.Linq.Expressions;

namespace Demo01.Repositories
{
    public interface IRepository<TEntity>
    {
        //CREATE
        int Add(TEntity contact);
        // READ
        TEntity? GetById(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        // UPDATE
        bool Update(TEntity contact);
        // DELETE
        bool Delete(int id);
    }
}
