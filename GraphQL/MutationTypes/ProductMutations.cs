using graphql_dotnet.Dto;
using graphql_dotnet.Entities;
using graphql_dotnet.Repositories;
using HotChocolate;

namespace graphql_dotnet.GraphQL.Mutations
{
    public class ProductMutations
    {
        public async Task<ProductDetailCreateResult> AddProductAsync([Service] IProductService productService,
    ProductDetailCreate productDetails)
        {
            return await productService.AddProductAsync(productDetails);
        }

        public async Task<bool> UpdateProductAsync([Service] IProductService productService,
    ProductDetailUpdate productDetails)
        {
            return await productService.UpdateProductAsync(productDetails);
        }

        public async Task<bool> DeleteProductAsync([Service] IProductService productService,
   Guid productId)
        {
            return await productService.DeleteProductAsync(productId);
        }
    }
}
