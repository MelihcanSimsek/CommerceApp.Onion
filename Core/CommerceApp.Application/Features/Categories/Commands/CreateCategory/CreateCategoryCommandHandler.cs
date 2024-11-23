using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Categories.Rules;
using CommerceApp.Application.Interfaces.AutoMapper;
using CommerceApp.Application.Interfaces.UnitOfWorks;
using CommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CommerceApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules categoryRules;
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category? checkCategory = await unitOfWork.GetReadRepository<Category>().GetAsync(p => p.Id == request.ParentId);
            await categoryRules.WhenParentIdGreaterThanZeroShoukdBeExistsCategory(checkCategory, request.ParentId);
            Category category = mapper.Map<Category, CreateCategoryCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
