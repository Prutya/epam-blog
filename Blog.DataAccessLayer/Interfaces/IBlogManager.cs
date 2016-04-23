using Blog.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace Blog.DataAccessLayer.Interfaces
{
    public interface IBlogManager<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
