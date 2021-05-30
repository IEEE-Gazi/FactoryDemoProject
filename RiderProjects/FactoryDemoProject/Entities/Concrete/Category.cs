using System;
using System.Collections.Generic;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CategoryName { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}