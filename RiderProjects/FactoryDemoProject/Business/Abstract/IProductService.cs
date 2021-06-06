using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService : IRepositoryService<Product>
    {
        List<Product> GetAllExceedProducts();
    }
}