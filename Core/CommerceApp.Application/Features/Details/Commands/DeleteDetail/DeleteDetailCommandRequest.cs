using CommerceApp.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Commands.DeleteDetail
{
    public class DeleteDetailCommandRequest: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
