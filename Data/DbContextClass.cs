using graphql_dotnet.Data.Maping;
using graphql_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace graphql_dotnet.Data
{
    public partial class DbContextClass : DbContext
    {
        public DbSet<ProductDetails> Products { get; set; }

        public DbContextClass()
        {
        }

        public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("YourConnectionStringKey");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<ProductDetails>(new ProductDetailsMap().Configure);
            modelBuilder.Entity<ProductDetails>().HasData(
                                    new ProductDetails
                                    {
                                        Id = Guid.NewGuid(),
                                        ProductName = "IPhone",
                                        ProductDescription = "IPhone 14",
                                        ProductPrice = 120000,
                                        ProductStock = 100
                                    },
                    new ProductDetails
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "Samsung TV",
                        ProductDescription = "Smart TV",
                        ProductPrice = 400000,
                        ProductStock = 120
                    });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
