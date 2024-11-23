﻿using CommerceApp.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer redisConnection;
        private readonly IDatabase database;
        private readonly RedisSettings redisSettings;

        public RedisCacheService(IOptions<RedisSettings> options)
        {
            this.redisSettings = options.Value;
            var opt = ConfigurationOptions.Parse(redisSettings.ConnectionString);
            redisConnection = ConnectionMultiplexer.Connect(opt);
            database = redisConnection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await database.StringGetAsync(key);
            if(value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }

        public Task RemoveAsync(string key)
        {
            database.KeyDeleteAsync(key);
            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUnitExpiration = expirationTime.Value - DateTime.Now;
            database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);
            return Task.CompletedTask;
        }
    }
}
