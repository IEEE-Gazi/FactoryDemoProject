using System;
using System.Collections.Generic;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Adress { get; set; }
        public decimal Price { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}