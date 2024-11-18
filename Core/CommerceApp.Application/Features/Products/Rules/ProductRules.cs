using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Products.Exceptions;
using CommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task CheckIsProductTitleDuplicate(IList<Product> products, string requestProductTitle)
        {
            if (products.Any(p => p.Title == requestProductTitle)) throw new ProductTitleDuplicatedException();
            return Task.CompletedTask;
        }
    }
}
