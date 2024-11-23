using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Details.Exceptions;
using CommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Rules
{
    public class DetailRules : BaseRules
    {
        public async Task ShouldCategoryExistsWhenDetailCreating(Category? category)
        {
            if (category is null) throw new CategoryNotExistsException();
        }

        public async Task ShouldCategoryExistsWhenDetailUpdating(Category? category)
        {
            if (category is null) throw new CategoryNotExistsException();
        }

        public async Task ShouldDetailExistsWhenDeleting(Detail? detail)
        {
            if (detail is null) throw new DetailNotExistsException();
        }

        public async Task ShouldDetailExistsWhenUpdating(Detail? detail)
        {
            if (detail is null) throw new DetailNotExistsException();
        }
    }
}
