using CommerceApp.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetALLBrandsQueryRequest : ICacheableQuery,IRequest<IList<GetALLBrandsQueryResponse>>
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 30;
    }
}
