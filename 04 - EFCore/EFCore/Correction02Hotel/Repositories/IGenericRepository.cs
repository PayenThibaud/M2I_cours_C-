using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Hotel.Repositories
{
    internal interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity? GetOneById(int id);

        // Le type Expression permet de passer une expression LinQ qui sera utilisée dans la méthode .Where()
        // Cette expression sera ensuite traduite en SQL
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

    }
}
