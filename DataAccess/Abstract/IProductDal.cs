using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // Product ile ilgili veri erişim  methodları yazdgımız kısımdır.
   public interface IProductDal : IEntityRepository<Product>
    {
        // şuan sadece efproductdala özel operasyonlar için kullanabiliriz burayı
        List<ProductDetailDto> GetProductDetails();

    }
}
