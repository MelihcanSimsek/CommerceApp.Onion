using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id && p.IsDeleted == false);
            if (product is null) throw new NotFoundException("Product not found");

            var updateProduct = mapper.Map<Product, UpdateProductCommandRequest>(request);
            updateProduct.Id = product.Id;
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(updateProduct);

            var categoriesforDeleting = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(p => p.ProductId == request.Id);
            await unitOfWork.GetWriteRepository<ProductCategory>().DeleteRangeAsync(categoriesforDeleting);

            foreach (var categoryId in request.CategoryIds)
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                {
                    CategoryId = categoryId,
                    ProductId = request.Id
                });
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
