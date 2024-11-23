using CommerceApp.Application.Bases;
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

namespace CommerceApp.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler, IRequestHandler<GetALLBrandsQueryRequest, IList<GetALLBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<IList<GetALLBrandsQueryResponse>> Handle(GetALLBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Brand> brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync(p=> !p.IsDeleted);
            IList<GetALLBrandsQueryResponse> response = mapper.Map<GetALLBrandsQueryResponse, Brand>(brands);

            return response;
        }
    }
}
