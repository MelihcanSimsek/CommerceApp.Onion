using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Brands.Rules;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        private readonly BrandRules brandRules;
        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.brandRules = brandRules;
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Brand> brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            await brandRules.ShouldBrandNameCanNotBeDuplicate(brands, request.Name);
            Brand brand =  mapper.Map<Brand, CreateBrandCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Brand>().AddAsync(brand);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
