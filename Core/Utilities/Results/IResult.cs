using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler için başlangıç
    // apilere verilecek işlem sonucu bilgilendirme.
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
