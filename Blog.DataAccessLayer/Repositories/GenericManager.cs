using Blog.DataAccessLayer.EF;
using Blog.DataAccessLayer.Interfaces;
using Blog.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.DataAccessLayer.Repositories
{
    public class GenericManager<TEntity> : IBlogManager<TEntity> where TEntity : Entity
    {
        private readonly BlogDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericManager(BlogDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }
        public void Delete(int id)
        {
            TEntity item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }
        }
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }
        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
