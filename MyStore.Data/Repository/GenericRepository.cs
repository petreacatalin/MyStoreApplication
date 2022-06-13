using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore.Entities;
using MyStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MyStore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyStoreContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(MyStoreContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Delete(object Id)
        {
            T exists = _table.Find(Id);
            _table.Remove(exists);
            return exists;
        }
               

        public IEnumerable<T> GetAll()
        {
            var item = _table;
            return item;

        }

        public T GetById(object Id)
        {

            var item = _table.Find(Id);
            return item;
        }

        public T Insert(T obj)
        {
            var result = _table.Add(obj);
            return result.Entity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
