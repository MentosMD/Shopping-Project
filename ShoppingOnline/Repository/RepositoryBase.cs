using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.Models;
using AppContext = ShoppingOnline.Context.AppContext;

namespace ShoppingOnline.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly AppContext _context;

        public RepositoryBase(AppContext context)
        {
            _context = context;
        }
        
        public void AddNewEntity(T newEntity)
        {
            if (newEntity == null) throw new ArgumentNullException("Entity");
            _context.Set<T>().Add(newEntity);
            _context.SaveChanges();
        }

        public void UpdateEntity(T updateEntity)
        {
            if (updateEntity == null) throw new ArgumentNullException("Entity");
            _context.Set<T>().Update(updateEntity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public void DeleteEntity(int id)
        {
            if (id == null) throw new ArgumentNullException("Entity");
            T entity = _context.Set<T>().SingleOrDefault(s => s.ID == id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}