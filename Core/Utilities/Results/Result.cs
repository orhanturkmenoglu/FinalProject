using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // set'i : contstructor parametresi ile geçiyoruz. getterlar read onlydir constructorla set edilebilir.
        // iki farklı constructor oluşturmamızın nedeni kullanıcı her iki parametreyede bagımlı olmamaısnı saglamak istedigini yazıp istemedigini yazmayabilsin 
        // :this(success): burda iki paremetre gonderen birisi için ama aynı zamanda bu classta tek parametre olanı da çalıştır.
        // Yani constructor 1 çalışırken ikincı constructorda birlikte çalışacak.
        public Result(bool success,string message) :this(success)
        {
            Message = message;
            //  Success = success; kod tekrarı yapmamak için  :this(success) constructor base ile çalıştık alt consturctorda çalışacak.
        }

        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }


    }
}
