using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Auth.Rules;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.Tokens;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(
            UserManager<User> userManager,
            AuthRules authRules,
            IConfiguration configuration,
            ITokenService tokenService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email);
            bool passwordCheck = await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.ShouldUserEmailAndPasswordIsCorrect(user, passwordCheck);

            List<string> roles = (List<string>)await userManager.GetRolesAsync(user);

            JwtSecurityToken _token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["TokenOptions:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);


            string token = new JwtSecurityTokenHandler().WriteToken(_token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", token);

            return new()
            {
                AccessToken = token,
                RefreshToken = refreshToken,
                Expiration = _token.ValidTo
            };

        }
    }
}
