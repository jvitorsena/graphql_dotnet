using graphql_dotnet.Entities;
using graphql_dotnet.Repositories;
using HotChocolate;

namespace graphql_dotnet.GraphQL.Types
{
    public class ProductQueryTypes
    {
        public async Task<List<ProductDetails>> GetProductListAsync([Service] IProductService productService)
        {
            return await productService.ProductListAsync();
        }

        public async Task<ProductDetails> GetProductDetailsByIdAsync([Service] IProductService productService, Guid productId)
        {
            return await productService.GetProductDetailByIdAsync(productId);
        }
    }
}
