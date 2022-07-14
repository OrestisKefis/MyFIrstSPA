using MyDatabase;
using RepositoryService.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext db;
        public DbSet<T> table;
        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        public void Delete(object id)
        {
            var entity = table.Find(id);
            db.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            db.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
