using graphql_dotnet.Dto;
using graphql_dotnet.Entities;

namespace graphql_dotnet.Repositories
{
    public interface IProductService
    {
        public Task<List<ProductDetails>> ProductListAsync();

        public Task<ProductDetails> GetProductDetailByIdAsync(Guid productId);

        public Task<ProductDetailCreateResult> AddProductAsync(ProductDetailCreate productDetails);

        public Task<bool> UpdateProductAsync(ProductDetailUpdate productDetails);

        public Task<bool> DeleteProductAsync(Guid productId);
    }
}
