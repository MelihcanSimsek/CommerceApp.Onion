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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) :
            base(unitOfWork, mapper, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExistsWhenRegistered(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user,request.Password);

            if (result.Succeeded)
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role()
                    {
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER"
                    });

            await userManager.AddToRoleAsync(user, "user");

            return Unit.Value;
        }
    }
}
