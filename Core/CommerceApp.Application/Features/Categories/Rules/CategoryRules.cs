using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Categories.Exceptions;
using CommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Categories.Rules
{
    public class CategoryRules :BaseRules
    {
        public async Task WhenParentIdGreaterThanZeroShoukdBeExistsCategory(Category? category, int parentId)
        {
            if (category is null && parentId > 0) throw new CategoryParentDoesNotExistsException();
        }

        public async Task ShouldCategoryExistsWhenDeleting(Category? category)
        {
            if (category is null) throw new CategoryDoesNotExistsException();
        }

        public async Task ShouldCategoryExistsWhenUpdating(Category? category)
        {
            if (category is null) throw new CategoryDoesNotExistsException();
        }
    }
}
