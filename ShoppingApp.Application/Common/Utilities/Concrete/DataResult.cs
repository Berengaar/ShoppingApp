using ShoppingApp.Application.Common.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Utilities.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult()
        {

        }
        public DataResult(bool resultStatus, T data)
        {
            Success = resultStatus;
            Data = data;
        }
        public DataResult(bool resultStatus, string message, T data)
        {
            Success = resultStatus;
            Message = message;
            Data = data;
        }

        public T Data { get; private set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
