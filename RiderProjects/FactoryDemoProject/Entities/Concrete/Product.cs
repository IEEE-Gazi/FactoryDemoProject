using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CategoryId { get; set; }
        public Guid? OrderDetailId { get; set; }
        
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }

        public Category Category { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}