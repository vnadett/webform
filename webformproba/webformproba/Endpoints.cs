using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webformproba
{
    public class Endpoints
    {
        private static readonly string BASEURL = "https://localhost:44394/api/";
        //products
        public static string ProductEndpoint = BASEURL + "Product/";
    }
}