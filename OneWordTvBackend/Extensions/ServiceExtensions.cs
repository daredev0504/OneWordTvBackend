using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OneWordTvBackend.Data;
using OneWordTvBackend.Repository;
using OneWordTvBackend.Service;

namespace OneWordTvBackend.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContextForPostgresql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetSection("PG_ConnectionStrings:connString").Value));
        }

        public static void ConfigureOneTvProgramService(this IServiceCollection services) => services.AddScoped<IOneWordTvService, OneWordTvService>();
        public static void ConfigureOneTvProgramRepository(this IServiceCollection services) => services.AddScoped<IOneWordProgramRepository, OneWordProgramRepository>();

    }
}
