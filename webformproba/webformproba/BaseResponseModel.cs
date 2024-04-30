using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webformproba
{
    public class BaseResponseModel<T>
    {
        public bool Success { get; set; }

        public T Result { get; set; }
        public string Message { get; set; }
    }
}