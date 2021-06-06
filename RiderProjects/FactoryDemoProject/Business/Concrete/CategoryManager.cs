using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : EfEntityRepositoryManager<Category, ICategoryDal>,  ICategoryService
    {
        public CategoryManager(ICategoryDal categoryDal) : base(categoryDal)
        {
            
        }
    }
}