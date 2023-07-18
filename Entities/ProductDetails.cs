using System.ComponentModel.DataAnnotations;

namespace graphql_dotnet.Entities
{
    public class ProductDetails : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
