using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _productList = new List<Product>();

        public InMemoryProductDal()
        {
            _productList = new List<Product>
            {

                new Product(){ProductId=1,CategoryId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
                new Product(){ProductId=2,CategoryId=1,ProductName="Kamera",UnitsInStock=3,UnitPrice=500},
                new Product(){ProductId=3,CategoryId=2,ProductName="Telefon",UnitsInStock=2,UnitPrice=1500},
                new Product(){ProductId=4,CategoryId=2,ProductName="Fare",UnitsInStock=65,UnitPrice=150},
                new Product(){ProductId=5,CategoryId=2,ProductName="Klavye",UnitsInStock=15,UnitPrice=85},

            };
        }

        public void Add(Product product)
        {
            _productList.Add(product);
        }

        public void Delete(Product product)
        {
            // Linq: ile dile gömülü sorgulama yaparız liste bazlı uygulamaları
            Product productToDelete = _productList.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _productList.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _productList;
        }

        public List<Product> GetAllByCategory(int categorydId)
        {
            // Şarta göre yeni bir tablo oluşturmamızı saglar.
            return _productList.Where(p=>p.CategoryId==categorydId).ToList();
        }

        public void Update(Product product)
        {
            // gönderdigim ürün idsine sahip urunu bul
            Product productToUpdate = _productList.SingleOrDefault(p=>p.ProductId==p.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
         
        }
    }
}
