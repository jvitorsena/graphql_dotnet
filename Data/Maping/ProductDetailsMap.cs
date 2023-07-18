using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using graphql_dotnet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace graphql_dotnet.Data.Maping
{
    public class ProductDetailsMap : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.ToTable("ProductDetails");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductDescription).HasMaxLength(50);
            builder.Property(p => p.ProductName).HasMaxLength(25);
            builder.Property(p => p.ProductPrice);
            builder.Property(p => p.ProductStock);
        }
    }
}