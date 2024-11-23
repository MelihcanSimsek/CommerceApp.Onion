using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Brands.Exceptions;
using CommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Rules
{
    public class BrandRules : BaseRules
    {
        public async Task ShouldBrandNameCanNotBeDuplicate(IList<Brand> brands,string brandName)
        {
            if (brands.Any(p => p.Name == brandName)) throw new BrandNameCanNotBeDuplicatedException();
        }

        public async Task ShouldBrandExistsWhenUpdating(Brand? brand)
        {
            if (brand is null) throw new BrandNotFoundException();
        }

        public async Task ShouldBrandExistsWhenDeleting(Brand? brand)
        {
            if (brand is null) throw new BrandNotFoundException();
        }
    }
}
