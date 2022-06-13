
using MyStore.DTOs;
using MyStore.Entities;
using MyStore.Interfaces;
using System;

namespace MyStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStoreContext _context;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Customer> _customers;

        public UnitOfWork(MyStoreContext context)
        {
            _context = context;
        }

        //public IGenericRepository<Category> GenericRepository => new GenericRepository<Category>(_context);

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Customer> Customers => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }



    }
}
