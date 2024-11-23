using CommerceApp.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandRequest:IRequest<Unit>,ICacheRemoverCommand
    {
        public int Id { get; set; }

        public string CacheKey => "GetAllBrands";
    }
}
