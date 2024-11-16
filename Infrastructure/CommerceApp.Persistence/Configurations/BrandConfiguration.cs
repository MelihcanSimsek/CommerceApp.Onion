using Bogus;
using CommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            Faker faker = new("en");

            Brand brand1 = new()
            {
                Id = 1,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Name = faker.Commerce.Department()
            };

            Brand brand2 = new()
            {
                Id = 2,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Name = faker.Commerce.Department()
            };

            Brand brand3 = new()
            {
                Id = 3,
                CreationDate = DateTime.Now,
                IsDeleted = true,
                Name = faker.Commerce.Department()
            };

            builder.HasData(brand1, brand2, brand3);
        }
    }
}
