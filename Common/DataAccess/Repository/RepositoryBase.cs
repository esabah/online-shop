using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            _dbContext.Set<T>().Remove(GetById(id));
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                throw new ArgumentException($"Object not found with Id {id}");
            }
            else return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
