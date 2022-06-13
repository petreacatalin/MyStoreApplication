using MyStore.DTOs;
using MyStore.Entities;
using MyStore.Repository;
using System;
using System.Collections.Generic;

namespace MyStore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }      
        IGenericRepository<Customer> Customers { get; }

       // T GetRepository<T>() where T : class, new();

        void Save();        
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    }
}
