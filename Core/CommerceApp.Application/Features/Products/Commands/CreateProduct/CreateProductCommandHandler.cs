using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Products.Rules;
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

namespace CommerceApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly ProductRules productRules;
        public CreateProductCommandHandler(ProductRules productRules, IUnitOfWork unitOfWork,IMapper mapper, IHttpContextAccessor httpContextAccessor):base(unitOfWork,mapper,httpContextAccessor)
        {
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
            await productRules.CheckIsProductTitleDuplicate(products, request.Title);

            var product = mapper.Map<Product, CreateProductCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>()
                        .AddAsync(new ProductCategory(product.Id, categoryId));
                
                await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }

    }
}
