using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // InMemoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + " / " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }



            // GetAllTest(productManager);

            // GetAllByCategoryIdTest(productManager);

            // GetByUnitPriceTest(productManager);

            // CategoryManagerTest();

           // ProductDetailDto(productManager);

            Console.ReadLine();
        }

        private static void ProductDetailDto(ProductManager productManager)
        {
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }

        private static void CategoryManagerTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
          
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void GetByUnitPriceTest(ProductManager productManager)
        {
            foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void GetAllByCategoryIdTest(ProductManager productManager)
        {
            foreach (var product in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void GetAllTest(ProductManager productManager)
        {
            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void InMemoryTest()
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
