using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Auth.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Exceptions
{
    public class PasswordChangeException : BaseException
    {
        public PasswordChangeException() : base(Messages.AnErrorOccurredWhenPasswordChanging)
        {
            
        }
    }
}
