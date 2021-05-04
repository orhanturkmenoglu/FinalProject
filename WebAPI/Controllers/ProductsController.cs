using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // route bize nasıl istekte bulunacaklarını bilgilendirir.
    [ApiController] // attribute : bir class ile ilgili bilgi verme onu imzalama yöntemidir.
    public class ProductsController : ControllerBase
    {
        //[HttpGet]
        //public List<Product> Get()
        //{
        //    return new List<Product>
        //    {
        //        new Product()
        //        {
        //            ProductId=1,
        //            ProductName="Elma"
        //        },
        //          new Product()
        //        {
        //            ProductId=2,
        //            ProductName="Armut"
        //        }
        //    };
        //}

        //[HttpGet]
        //public List<Product> Get()
        //{
        //    IProductService service = new ProductManager(new EfProductDal());
        //    var result = service.GetAll();
        //    return result.Data;
        //}

        // Loosely coupled :gevşek bagımlılık. soyuta baglı yani. 
        // IoC Container : 
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public List<Product> Get()
        //{
        //    var result = _productService.GetAll();
        //    return result.Data;
        //}



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); // Ok()işlem başarılı ise datayı ve mesajı  dönder Ok() gönderirsen sadece başarılı oldugunu görürsün
            }

            return BadRequest(result); // badrequest(result): işlem başarısız ise mesaj data yı dönderir 


        }


        [HttpGet("getbyid")] // isimlerle alians veriyoruz birden fazla get ve post istekleri olduğu için 

        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("add")] // data ekleme silme güncelleme 
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


    }
}
