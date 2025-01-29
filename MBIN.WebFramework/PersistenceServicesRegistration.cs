using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Data.Context;
using MBIN.Data.Contracts;
using MBIN.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MBIN.Data.Context;

namespace MBIN.WebFramework
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection service, IConfiguration configuration)
        {
            #region Context

            service.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            #endregion

            #region Dependency

            service.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            service.AddScoped<IUserRepository, UserRepository>();

            #endregion

            return service;

        }
    }
}
