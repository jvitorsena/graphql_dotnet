using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnet.Dto
{
    public class ProductDetailCreate
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}