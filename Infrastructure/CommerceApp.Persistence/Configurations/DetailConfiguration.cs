using Bogus;
using CommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommerceApp.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("en");

            Detail detail1 = new()
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(10),
                CategoryId = 1,
                IsDeleted = false
            };

            Detail detail2 = new()
            {
                Id = 2,
                CreationDate = DateTime.Now,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(7),
                CategoryId = 3,
                IsDeleted = true
            };

            Detail detail3 = new()
            {
                Id = 3,
                CreationDate = DateTime.Now,
                Title = faker.Lorem.Sentence(3),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                IsDeleted = false
            };

            builder.HasData(detail1, detail2, detail3);
        }
    }
}
