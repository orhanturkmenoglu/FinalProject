using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICategoryDal :IEntityRepository<Category>
    {
     // Category e ait özel methodlar için kullanılır artık genel operasyonlar crud(add,delete,update.vb) IEntityRepositoryden saglanıyor. 
    }
}
