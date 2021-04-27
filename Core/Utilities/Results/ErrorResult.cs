using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        // tek parametre olanı çalıştır demek basedeki false default vermiş olduk.
        public ErrorResult() : base(false)
        {

        }
    }
}
