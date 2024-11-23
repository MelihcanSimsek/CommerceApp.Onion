using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Details.Commands.UpdateDetail
{
    public class UpdateDetailCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
