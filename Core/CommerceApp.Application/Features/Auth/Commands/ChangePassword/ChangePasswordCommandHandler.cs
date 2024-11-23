using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Auth.Rules;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : BaseHandler,IRequestHandler<ChangePasswordCommandRequest,Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, AuthRules authRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            User? user =  await userManager.FindByEmailAsync(request.Email);
            await authRules.ShouldEmailValidWhenChangingPassword(user);
            bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.ShouldCurrentPasswordIsCorrectWhenPasswordChanging(isPasswordCorrect);
            IdentityResult result = await userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
            await authRules.ShouldPasswordChangingSucceeded(result);
            return Unit.Value;
        }
    }
}
