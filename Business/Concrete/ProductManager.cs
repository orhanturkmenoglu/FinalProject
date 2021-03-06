using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {


            //// fluent validation kullanma bütün projelerimizde kullanmak için bu yapıyı tools  yapcaz core katmanında
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);

            //if (!result.IsValid) // ısvalid geçerli olup olmadığı
            //{
            //    throw new ValidationException(result.Errors);
            //}

            // tool haline getirdik.
            ValidationTool.Validate(new ProductValidator(), product);


            // fluent validation ile yazdık.
            //if (product.UnitPrice<=0)
            //{
            //    return new ErrorResult();
            //}

            //if (product.ProductName.Length <2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            // business codes
            _productDal.Add(product);

            // constructora parametre yollayarak işlemin başarılı veya başarısız ve message  vererek bilgilendirme yapıcaz.set kısmını constructor ile vermiş oluyoruz.
            return new SuccesResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccesResult(Messages.ProductDeleted);

        }

        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }


        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
           
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccesResult(Messages.ProductUpdated);
        }


    }
}
