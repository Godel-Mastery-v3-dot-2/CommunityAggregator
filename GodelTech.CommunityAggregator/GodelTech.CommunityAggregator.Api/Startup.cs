using System.IO;
using GodelTech.CommunityAggregator.Dal.EntityFramework;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using GodelTech.CommunityAggregator.Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GodelTech.CommunityAggregator.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string conncetionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<EntityContext>(option => option.UseSqlServer(conncetionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
