using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Core.Utilities.Result.Success
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
