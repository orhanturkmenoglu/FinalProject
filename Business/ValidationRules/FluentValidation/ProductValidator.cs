using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        // RuleFor(): kim için kural
        // olmayan bir kural oluşturmak için method oluştururuz.
        // WithMessage(): hata mesajı yazmak istersek 
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2); // productName minimum iki karakter olmalıdır kuralı
            RuleFor(p => p.ProductName).NotEmpty(); // name boş olamaz
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); // unitprice 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); // unitprice fiyati 10 liradan büyük olmalı category ıd 1 olduğu zaman
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); // olmayan bir kural eklemek.StartWithA kendi yazacağımız method
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
