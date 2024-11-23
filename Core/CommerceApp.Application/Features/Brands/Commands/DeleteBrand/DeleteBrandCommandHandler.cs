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

namespace CommerceApp.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : BaseHandler, IRequestHandler<DeleteBrandCommandRequest, Unit>
    {
        private readonly BrandRules brandRules;
        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, BrandRules brandRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.brandRules = brandRules;
        }

        public async Task<Unit> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand? brand = await unitOfWork.GetReadRepository<Brand>().GetAsync(p => p.Id == request.Id);
            await brandRules.ShouldBrandExistsWhenDeleting(brand);

            brand.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Brand>().UpdateAsync(brand);

            return Unit.Value;
        }
    }
}
