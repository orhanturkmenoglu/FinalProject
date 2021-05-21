using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            // fluent validation kullanma bütün projelerimizde kullanmak için bu yapıyı tools  yapcaz core katmanında
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid) // ısvalid geçerli olup olmadığı
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
