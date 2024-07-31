using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUDnet7.Services
{
    public interface ICRUDService<TEntity>
    {

        public Task<TEntity?> Get(int id);
        public Task<List<TEntity>> GetAll();
        public Task<bool> Post(TEntity pizza);
        public Task<bool> Put(TEntity pizza);
        public Task<bool> Delete(int id);
    }
}
