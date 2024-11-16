using Bogus;
using CommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CommerceApp.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("en");

            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.Discount).HasPrecision(18, 2);

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description= faker.Commerce.ProductDescription(),
                CreationDate = DateTime.Now,
                IsDeleted = false,
                BrandId = 1,
                Discount = Math.Round(faker.Random.Decimal(0, 10),2) ,
                Price = Math.Round(faker.Finance.Amount(10, 100),2) 
            };


            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreationDate = DateTime.Now,
                IsDeleted = false,
                BrandId = 3,
                Discount = Math.Round(faker.Random.Decimal(0, 10),2) ,
                Price = Math.Round(faker.Finance.Amount(10, 100),2) 
            };


            builder.HasData(product1, product2);
        }
    }
}
