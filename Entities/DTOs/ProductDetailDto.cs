using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    // Dto:Data transformation object:benim taşıyacagım objeler demek.
    // Dtos: birden fazla tabloyu ilişkilendirdiğimiz kısım.
    // Join operasyonudur.
    // IDto:birden fazla tablonun joini olduğu için bu bir Dtodur.Tek başına bir tabloya karşılık gelmiyor 
   public class ProductDetailDto :IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
