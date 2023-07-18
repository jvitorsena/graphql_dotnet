using AutoMapper;
using graphql_dotnet.Data;
using graphql_dotnet.Dto;
using graphql_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace graphql_dotnet.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass dbContextClass;
        private readonly IMapper _mapper;

        public ProductService(DbContextClass dbContextClass)
        {
            this.dbContextClass = dbContextClass;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDetails, ProductDetailCreate>().ReverseMap();
                cfg.CreateMap<ProductDetailCreate, ProductDetails>().ReverseMap();
                cfg.CreateMap<ProductDetails, ProductDetailUpdate>().ReverseMap();
                cfg.CreateMap<ProductDetailUpdate, ProductDetails>().ReverseMap();
                cfg.CreateMap<ProductDetails, ProductDetailCreateResult>().ReverseMap();
                cfg.CreateMap<ProductDetailCreateResult, ProductDetails>().ReverseMap();
            });
            this._mapper = new Mapper(config);
        }

        public async Task<List<ProductDetails>> ProductListAsync()
        {
            return await dbContextClass.Products.ToListAsync();
        }

        public async Task<ProductDetails> GetProductDetailByIdAsync(Guid productId)
        {
            return await dbContextClass.Products.Where(ele => ele.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<ProductDetailCreateResult> AddProductAsync(ProductDetailCreate productDetailsCreate)
        {
            try
            {
                ProductDetails productDetail = _mapper.Map<ProductDetails>(productDetailsCreate);
                productDetail.Id = Guid.NewGuid();
                productDetail.CreateAt = DateTime.UtcNow;
                productDetail.updateAt = DateTime.UtcNow;
                productDetail.IsActive = true;

                await dbContextClass.Products.AddAsync(productDetail);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    ProductDetailCreateResult createResult = _mapper.Map<ProductDetailCreateResult>(productDetail);
                    return createResult;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred in save data: " + ex.Message, ex);
            }
        }

        public async Task<bool> UpdateProductAsync(ProductDetailUpdate productDetails)
        {
            ProductDetails product = await dbContextClass.Products.SingleOrDefaultAsync(p => p.Id.Equals(productDetails.Id));
            var isProduct = ProductDetailsExists(productDetails.Id);
            if (isProduct)
            {
                ProductDetails productDetail = _mapper.Map<ProductDetails>(productDetails);
                productDetail.updateAt = DateTime.UtcNow;
                productDetail.CreateAt = product.CreateAt;

                dbContextClass.Products.Update(productDetail);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var findProductData = dbContextClass.Products.Where(_ => _.Id == productId).FirstOrDefault();
            if (findProductData != null)
            {
                dbContextClass.Products.Remove(findProductData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool ProductDetailsExists(Guid productId)
        {
            return dbContextClass.Products.Any(e => e.Id == productId);
        }

        public Task<bool> UpdateProductAsync(ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }
    }
}
