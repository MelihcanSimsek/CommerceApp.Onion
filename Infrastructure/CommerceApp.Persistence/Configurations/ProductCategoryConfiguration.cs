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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(p=> new {p.ProductId,p.CategoryId});

            builder.HasOne(p => p.Category).WithMany(p => p.ProductCategories).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(p => p.ProductCategories).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
