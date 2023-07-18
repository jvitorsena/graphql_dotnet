using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnet.Dto
{
    public class ProductDetailCreateResult
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsActive { get; set; }
    }
}