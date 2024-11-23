﻿using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Details.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Exceptions
{
    public class CategoryNotExistsException : BaseException
    {
        public CategoryNotExistsException():base(Messages.CategoryNotExists)
        {
            
        }
    }
}