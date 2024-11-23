using CommerceApp.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandRequest:IRequest<Unit>,ICacheRemoverCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CacheKey => "GetAllBrands";
    }
}
