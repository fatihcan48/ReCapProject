using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
