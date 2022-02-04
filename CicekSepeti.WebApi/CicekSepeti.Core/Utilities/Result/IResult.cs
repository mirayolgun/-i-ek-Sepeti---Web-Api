using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Core.Utilities.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
