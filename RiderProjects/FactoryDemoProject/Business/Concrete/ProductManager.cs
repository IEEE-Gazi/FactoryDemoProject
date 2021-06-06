using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : EfEntityRepositoryManager<Product, IProductDal>, IProductService
    {
        public ProductManager(IProductDal productDal) : base(productDal)
        {
            
        }

        public override void Add(Product entity)
        {
            if (DateTime.Now.Hour != 23)
            {
                base.Add(entity);
            }
            else
            {
                Console.WriteLine("Sistem bakımda");
            }
            
        }

        public List<Product> GetAllExceedProducts()
        {
            return base._data.GetAll(p => p.OrderDetailId == null);
        }
    }
}