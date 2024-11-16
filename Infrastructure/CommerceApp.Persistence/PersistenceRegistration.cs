using CommerceApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Persistence
{
    public static class PersistenceRegistration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(opt=>opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
