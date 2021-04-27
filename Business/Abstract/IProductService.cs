using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // iş kurallarını yazarız
    // void olan yerde IResult dönderecez bundan sonra apiyi işlemin sonucuna göre bilgilendirmek için
    // List ve Product olan yerde bundan sonra IDataResult kullanıyoruz hem işlem sonucu hem data hemde mesaj içeren bir yapı görevi görecek
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
