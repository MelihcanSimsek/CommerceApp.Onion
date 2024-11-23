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

namespace CommerceApp.Application.Features.Details.Commands.DeleteDetail
{
    public class DeleteDetailCommandHandler : BaseHandler, IRequestHandler<DeleteDetailCommandRequest, Unit>
    {
        private readonly DetailRules detailRules;

        public DeleteDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, DetailRules detailRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.detailRules = detailRules;
        }

        public async Task<Unit> Handle(DeleteDetailCommandRequest request, CancellationToken cancellationToken)
        {
            Detail? detail = await unitOfWork.GetReadRepository<Detail>().GetAsync(p => p.Id == request.Id);
            await detailRules.ShouldDetailExistsWhenDeleting(detail);

            detail.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Detail>().UpdateAsync(detail);

            return Unit.Value;
        }
    }
}
