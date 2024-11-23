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

namespace CommerceApp.Application.Features.Details.Commands.UpdateDetail
{
    public class UpdateDetailCommandHandler : BaseHandler, IRequestHandler<UpdateDetailCommandRequest, Unit>
    {
        private readonly DetailRules detailRules;
        public UpdateDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, DetailRules detailRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.detailRules = detailRules;
        }

        public async Task<Unit> Handle(UpdateDetailCommandRequest request, CancellationToken cancellationToken)
        {
            Detail? detail = await unitOfWork.GetReadRepository<Detail>().GetAsync(p => p.Id == request.Id);
            await detailRules.ShouldDetailExistsWhenUpdating(detail);

            Category? category = await unitOfWork.GetReadRepository<Category>().GetAsync(p => p.Id == request.CategoryId);
            await detailRules.ShouldCategoryExistsWhenDetailUpdating(category);

            detail.Title = request.Title;
            detail.Description = request.Description;
            detail.CategoryId = request.CategoryId;

            await unitOfWork.GetWriteRepository<Detail>().UpdateAsync(detail);

            return Unit.Value;
        }
    }
}
