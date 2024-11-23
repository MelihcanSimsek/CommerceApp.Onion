using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Categories.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Categories.Exceptions
{
    public class CategoryParentDoesNotExistsException : BaseException
    {
        public CategoryParentDoesNotExistsException() : base(Messages.CategoryParentDoesNotExists)
        {
            
        }
    }
}
