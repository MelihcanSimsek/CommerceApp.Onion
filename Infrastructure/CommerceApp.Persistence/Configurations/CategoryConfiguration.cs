using Bogus;
using CommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerceApp.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category parent1 = new()
            {
                Id = 1,
                ParentId = 0,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Priority = 1,
                Name = "Electronics",
            };

            Category parent2 = new()
            {
                Id = 2,
                ParentId = 0,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Priority = 2,
                Name = "Foods",
            };

            Category category1 = new()
            {
                Id = 3,
                ParentId = 1,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Priority = 1,
                Name = "Computer",
            };

            Category category2 = new()
            {
                Id = 4,
                ParentId = 2,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Priority = 1,
                Name = "Meat",
            };

            builder.HasData(parent1, parent2, category1, category2);
        }
    }
}
