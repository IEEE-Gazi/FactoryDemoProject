using System;
using System.Collections.Generic;
using Entities.Abstract;

namespace Business.Abstract
{
    public interface IRepositoryService<T>
        where T: class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Guid id);
        List<T> GetAll();
    }
}