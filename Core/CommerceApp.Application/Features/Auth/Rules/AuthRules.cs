using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Auth.Exceptions;
using CommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

        public async Task ShouldUserRefreshTokenNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredExcepiton();
        }

        public async Task ShouldEmailValidWhenRevoked(User? user)
        {
            if (user is null) throw new EmailNotValidException();
        }

        public async Task ShouldEmailValidWhenChangingPassword(User? user)
        {
            if (user is null) throw new EmailNotValidException();
        }

        public async Task ShouldCurrentPasswordIsCorrectWhenPasswordChanging(bool checkPassword)
        {
            if (!checkPassword) throw new CurrentPasswordNotValidExcepiton();
        }

        public async Task ShouldPasswordChangingSucceeded(IdentityResult result)
        {
            if (!result.Succeeded) throw new PasswordChangeException();
        }
    }
}
