using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Products.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Products.Exceptions
{
    public class ProductTitleDuplicatedException : BaseExceptions
    {
        public ProductTitleDuplicatedException() : base(Messages.ProductTitleCanNotBeDuplicated)
        {

        }
    }
}
