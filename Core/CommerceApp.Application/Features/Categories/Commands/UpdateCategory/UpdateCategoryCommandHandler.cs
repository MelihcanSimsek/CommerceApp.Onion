using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Categories.Commands.CreateCategory;
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

namespace CommerceApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : BaseHandler, IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules categoryRules;
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category? category = await unitOfWork.GetReadRepository<Category>().GetAsync(p => p.Id == request.Id);
            await categoryRules.ShouldCategoryExistsWhenUpdating(category);

            Category? checkCategory = await unitOfWork.GetReadRepository<Category>().GetAsync(p => p.Id == request.ParentId);
            await categoryRules.WhenParentIdGreaterThanZeroShoukdBeExistsCategory(checkCategory, request.ParentId);

            category.ParentId = request.ParentId;
            category.Priority = request.Priority;
            category.Name = request.Name;
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);

            return Unit.Value;
        }
    }
}
