using CommerceApp.Application.Bases;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler,IRequestHandler<DeleteProductCommandRequest, Unit>
    {

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor):base(unitOfWork,mapper,httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id);
            if (product is null) throw new NotFoundException("Product not found");
            product.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
