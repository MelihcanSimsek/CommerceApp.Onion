﻿using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Bases
{
    public class BaseHandler
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IMapper mapper;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly string userId;

        public BaseHandler(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}