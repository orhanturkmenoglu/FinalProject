using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccesResult : Result
    {
        // base bir parametre gönderiyoruz bir üst classtaki constructorımız base olarak geçer
        // default true gönderdik ve message set etmelerini sagladık
        public SuccesResult(string message) : base(true,message)
        {

        }

        // tek parametre olanı çalıştır demek basedeki true default vermiş olduk.
        public SuccesResult() :base(true)
        {

        }

    }
}
