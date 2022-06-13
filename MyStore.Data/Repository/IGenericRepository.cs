using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyStore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        T Insert(T obj);
        void Update(T obj);
        T Delete(object Id);
     //   void Save();
    }
}
