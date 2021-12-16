using System;
using System.Collections.Generic;

namespace BetScore.Data.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        T Find(long id);
        IEnumerable<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
