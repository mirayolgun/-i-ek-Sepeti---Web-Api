using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Core.Utilities.Result.Error
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
