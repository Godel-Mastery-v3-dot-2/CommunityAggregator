using AutoMapper;
using GodelTech.CommunityAggregator.Bll.Interfaces;
using GodelTech.CommunityAggregator.Bll.Services;
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
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            string connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<EntityContext>(option => option.UseSqlServer(connectionString));
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        { 
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
