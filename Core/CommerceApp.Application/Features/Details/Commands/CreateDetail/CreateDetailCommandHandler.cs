using CommerceApp.Application.Bases;
using CommerceApp.Application.Features.Details.Rules;
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

namespace CommerceApp.Application.Features.Details.Commands.CreateDetail
{
    public class CreateDetailCommandHandler : BaseHandler, IRequestHandler<CreateDetailCommandRequest, Unit>
    {
        private readonly DetailRules detailRules;
        public CreateDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, DetailRules detailRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.detailRules = detailRules;
        }

        public async Task<Unit> Handle(CreateDetailCommandRequest request, CancellationToken cancellationToken)
        {
            Category? category = await unitOfWork.GetReadRepository<Category>().GetAsync(p => p.Id == request.CategoryId);
            await detailRules.ShouldCategoryExistsWhenDetailCreating(category);

            Detail detail = mapper.Map<Detail, CreateDetailCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Detail>().AddAsync(detail);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
