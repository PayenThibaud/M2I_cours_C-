using Demo01.Data;
using Demo01.Models;
using System.Linq.Expressions;

namespace Demo01.Repositories
{
    public class CrepeRepository : IRepository<Crepe>
    {
        private ApplicationDbContext _dbContext { get; }
        public CrepeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public int Add(Crepe crepe)
        {
            var addedObj = _dbContext.Crepes.Add(crepe);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id;
        }

        // READ
        public Crepe? GetById(int id)
        {
            return _dbContext.Crepes.Find(id);
        }
        public Crepe? Get(Expression<Func<Crepe, bool>> predicate)
        {
            return _dbContext.Crepes.FirstOrDefault(predicate);
        }
        public List<Crepe> GetAll()
        {
            return _dbContext.Crepes.ToList();
        }
        public List<Crepe> GetAll(Expression<Func<Crepe, bool>> predicate)
        {
            return _dbContext.Crepes.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Crepe crepe)
        {
            var crepeFromDb = GetById(crepe.Id);

            if (crepeFromDb == null)
                return false;

            if (crepeFromDb.Name != crepe.Name)
                crepeFromDb.Name = crepe.Name;
            if (crepeFromDb.IsSalty != crepe.IsSalty)
                crepeFromDb.IsSalty = crepe.IsSalty;
            if (crepeFromDb.Diameter != crepe.Diameter)
                crepeFromDb.Diameter = crepe.Diameter;
            if (crepeFromDb.Topping1 != crepe.Topping1)
                crepeFromDb.Topping1 = crepe.Topping1;
            if (crepeFromDb.Topping2 != crepe.Topping2)
                crepeFromDb.Topping2 = crepe.Topping2;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var crepe = GetById(id);
            if (crepe == null)
                return false;
            _dbContext.Crepes.Remove(crepe);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
