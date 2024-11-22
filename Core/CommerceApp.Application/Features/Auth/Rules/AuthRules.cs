﻿using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Auth.Exceptions;
using CommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Rules
{
    public class AuthRules:BaseRules
    {
        public async Task UserShouldNotBeExistsWhenRegistered(User? user)
        {
            if (user is not null) throw new UserAlreadyExistsExcepiton();
        }

        public async Task ShouldUserEmailAndPasswordIsCorrect(User? user,bool passwordCheck)
        {
            if (user is null || !passwordCheck) throw new EmailOrPasswordWrongExcepiton();
        }
    }
}