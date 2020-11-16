using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moradia.Data;
using System;
using System.Data.Entity.Infrastructure;

namespace Moradia
{
    public static class DIExtensions
    {
        //Add EF Core + Dapper
        public static void AddData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton(new SqlConnectionFactory(connectionString));
            services.AddSingleton<DataFactory>();
        }
    }
}
