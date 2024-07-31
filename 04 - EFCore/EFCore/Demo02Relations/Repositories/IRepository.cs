using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Repositories
{
    // Interface générique qui sera utilisée par tous les repositories
    // T fait référence au model, Tid au type de primary key du model (int, string, guid ...)
    // new() indique que le type T doit être une classe avec un constructeur de base
    internal interface IRepository<T, Tid> where T : new()
    {
        void Save(T entity);
        List<T> GetAll();
        
        // Le predicate va nous permetre de créer un filtre spécifique pour notre entité
        List<T> GetOneBySpecification(Expression<Func<T, bool>> predicate);
        T? GetOneById(Tid id);
        void Update(T entity);
        void Delete(T entity);
    }
}
