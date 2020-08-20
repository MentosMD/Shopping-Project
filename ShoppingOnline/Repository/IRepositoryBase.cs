using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.Models;

namespace ShoppingOnline.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public void AddNewEntity(TEntity newEntity);
        public void UpdateEntity(TEntity updateEntity);
        public TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll();
        public void DeleteEntity(int id);
    }
}