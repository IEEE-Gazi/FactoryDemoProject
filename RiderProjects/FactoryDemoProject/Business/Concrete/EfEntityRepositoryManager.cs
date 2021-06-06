using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;

namespace Business.Concrete
{
    public abstract class EfEntityRepositoryManager<TEntity, TData> : IRepositoryService<TEntity>
        where TEntity : class, IEntity, new()
        where TData : class, IEntityRepository<TEntity>
    {
        protected TData _data;

        public EfEntityRepositoryManager(TData data)
        {
            _data = data;
        }
        
        public virtual void Add(TEntity entity)
        {
            _data.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _data.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _data.Delete(entity);
        }

        public virtual TEntity Get(Guid id)
        {
            return _data.Get(p => p.Id == id);
        }

        public virtual List<TEntity> GetAll()
        {
            return _data.GetAll();
        }
    }
}