using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Brands.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Exceptions
{
    public class BrandNameCanNotBeDuplicatedException :BaseException
    {
        public BrandNameCanNotBeDuplicatedException():base(Messages.BrandNameCanNotBeDuplicated)
        {
            
        }
    }
}
