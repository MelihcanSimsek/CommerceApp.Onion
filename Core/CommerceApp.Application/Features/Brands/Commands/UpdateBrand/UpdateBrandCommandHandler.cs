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

namespace CommerceApp.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : BaseHandler, IRequestHandler<UpdateBrandCommandRequest, Unit>
    {
        private readonly BrandRules brandRules;
        public UpdateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.brandRules = brandRules;
        }

        public async Task<Unit> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand? brand = await unitOfWork.GetReadRepository<Brand>().GetAsync(p => p.Id == request.Id);
            await brandRules.ShouldBrandExistsWhenUpdating(brand);

            IList<Brand> brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            await brandRules.ShouldBrandNameCanNotBeDuplicate(brands, request.Name);

            brand.Name = request.Name;
            await unitOfWork.GetWriteRepository<Brand>().UpdateAsync(brand);

            return Unit.Value;
        }
    }
}
