using Demo02Relations.Data;
using Demo02Relations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Repositories
{
    // Classe qui va permettre la persistance des blogs en utilisant EFCore
    // On indique le type d'entité que l'on va manipuler, ainsi que le type de la clé primaire
    internal class BlogRepository : IRepository<Blog, int>
    {
        public void Delete(Blog entity)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            context.Blogs.Remove(entity);
            context.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            return context.Blogs.ToList();
        }

        public Blog? GetOneById(int id)
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            return context.Blogs.Find(id);
        }

        public List<Blog> GetOneBySpecification(Expression<Func<Blog, bool>> predicate)
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            return context.Blogs.Where(predicate).ToList();
        }

        public void Save(Blog entity)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            context.Blogs.Add(entity);
            context.SaveChanges();
        }

        public void Update(Blog entity)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            context.Blogs.Update(entity);
            context.SaveChanges();
        }
    }
}
