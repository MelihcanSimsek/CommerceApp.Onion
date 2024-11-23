using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Categories.Rules;
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

namespace CommerceApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : BaseHandler, IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules categoryRules;
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category? category = await unitOfWork.GetReadRepository<Category>().GetAsync(p => p.Id == request.Id);
            await categoryRules.ShouldCategoryExistsWhenDeleting(category);

            category.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);

            return Unit.Value;
        }
    }
}
