using System;
using System.Collections.Generic;
using System.Linq;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerOperations();

            // ProductManager productManager = new ProductManager(new EfProductDal());
            // foreach (var exceedProduct in productManager.GetAllExceedProducts())
            // {
            //     Console.WriteLine(exceedProduct.ProductName);
            // }
        }
        private static void ManagerOperations()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            Category category = categoryManager.Get(Guid.Parse("124B69D0-E679-4920-A9E1-DEEFDF8BF660"));

            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Add(new Product
            {
                CategoryId = category.Id, ProductName = "Greyfurt", UnitsInStock = 40
            });
        }

        private static void AddProduct1()
        {
            ICategoryDal efCategoryDal = new EfCategoryDal();
            Category category = efCategoryDal.Get(c => c.CategoryName == "Meyve Reyonu");

            IProductDal productDal = new EfProductDal();
            productDal.Add(new Product()
            {
                CategoryId = category.Id, ProductName = "Ayva", UnitsInStock = 25
            });
        }

        private static void AddCategoryAndOrder()
        {
            ICategoryDal categoryDal = new EfCategoryDal();
            categoryDal.Add(new Category {CategoryName = "Manav"});

            IOrderDetailDal orderDetailDal = new EfOrderDetailDal();
            orderDetailDal.Add(new OrderDetail {Adress = "Ankara", Price = 150});
        }

        private static void AddProduct2()
        {
            ICategoryDal efCategoryDal = new EfCategoryDal();
            Category category = efCategoryDal.Get(c => c.CategoryName == "Manav");

            IOrderDetailDal efOrderDetailDal = new EfOrderDetailDal();
            OrderDetail orderDetail = efOrderDetailDal.Get(o => o.Adress == "Ankara");

            IProductDal efProductDal = new EfProductDal();
            efProductDal.Add(new Product
            {
                CategoryId = category.Id, OrderDetailId = orderDetail.Id, ProductName = "Muz", UnitsInStock = 12
            });
        }

        private static void CreateDatabase()
        {
            using (var context = new FactoryContext())
            {
                context.Database.EnsureCreated();
            }
        }

        private static void FilteredGetSumAll()
        {
            IProductDal productDal = new EfProductDal();
            int sum = 0;
            List<Product> products = productDal.GetAll(p => p.ProductName == "Domates" || p.ProductName == "Salatalık");
            foreach (var product in products)
            {
                sum += product.UnitsInStock;
            }

            Console.WriteLine(sum);
        }

        private static void GetAll()
        {
            IProductDal productDal = new EfProductDal();

            List<Product> products = productDal.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AddMultipleProducts()
        {
            ICategoryDal efCategoryDal = new EfCategoryDal();
            Category category = efCategoryDal.Get(c => c.CategoryName == "Meyve Reyonu");

            IOrderDetailDal efOrderDetailDal = new EfOrderDetailDal();
            OrderDetail orderDetail = efOrderDetailDal.Get(o => o.Adress == "Konya");

            IProductDal productDal1 = new EfProductDal();
            productDal1.Add(new Product
            {
                ProductName = "Çilek", UnitsInStock = 35, CategoryId = category.Id, OrderDetailId = orderDetail.Id
            });

            IProductDal productDal2 = new EfProductDal();
            productDal2.Add(new Product
            {
                ProductName = "Erik", UnitsInStock = 26, CategoryId = category.Id, OrderDetailId = orderDetail.Id
            });

            IProductDal productDal3 = new EfProductDal();
            productDal3.Add(new Product
            {
                ProductName = "Domates", UnitsInStock = 16, CategoryId = category.Id
            });

            IProductDal productDal4 = new EfProductDal();
            productDal4.Add(new Product
            {
                ProductName = "Salatalık", UnitsInStock = 18, CategoryId = category.Id
            });
        }

        private static void DeleteProduct()
        {
            IProductDal productDal = new EfProductDal();
            Product product = productDal.Get(p => p.ProductName == "Ayva");

            productDal.Delete(product);
        }

        private static void GetAndUpdate()
        {
            ICategoryDal efCategoryDal = new EfCategoryDal();
            Category category = efCategoryDal.Get(c => c.CategoryName == "Manav");
            category.CategoryName = "Meyve Reyonu";

            IOrderDetailDal efOrderDetailDal = new EfOrderDetailDal();
            OrderDetail orderDetail = efOrderDetailDal.Get(o => o.Adress == "Ankara");
            orderDetail.Adress = "Konya";

            IOrderDetailDal orderDetailDal = new EfOrderDetailDal();
            orderDetailDal.Update(orderDetail);

            ICategoryDal categoryDal = new EfCategoryDal();
            categoryDal.Update(category);
        }
    }
}