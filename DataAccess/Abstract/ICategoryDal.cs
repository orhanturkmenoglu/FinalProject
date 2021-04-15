using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICategoryDal :IEntityRepository<Category>
    {
     // Category e ait özel methodlar için kullanılır artık genel operasyonlar ortaklar IEntityRepositoryden saglanıyor. 
    }
}
