using CommerceApp.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Behaviours
{
    public class RedisBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                string cacheKey = query.CacheKey;
                double cacheTime = query.CacheTime;

                TResponse value = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (value is not null)
                    return value;

                TResponse response = await next();
                if(response is not null)
                    await redisCacheService.SetAsync<TResponse>(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));

                return response;
            } else if(request is ICacheRemoverCommand command)
            {
                string cacheKey = command.CacheKey;
                await redisCacheService.RemoveAsync(cacheKey);
            }


            return await next();
        }
    }
}
