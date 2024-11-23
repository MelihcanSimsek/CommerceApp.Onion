using CommerceApp.Application.Bases;
using CommerceApp.Application.DTOs;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CommerceApp.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler :BaseHandler, IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: p => p.Include(c => c.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());
            var response = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in response)
                item.Price = item.Price - (item.Price * item.Discount / 100);


            return response;
        }
    }
}
