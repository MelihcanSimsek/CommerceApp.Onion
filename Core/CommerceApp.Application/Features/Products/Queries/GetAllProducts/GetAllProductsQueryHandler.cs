using CommerceApp.Application.DTOs;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommerceApp.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

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
