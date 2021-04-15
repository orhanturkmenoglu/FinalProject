using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // Product ile ilgili veri erişim  methodları yazdgımız kısımdır.
   public interface IProductDal : IEntityRepository<Product>
    {
      
    }
}
