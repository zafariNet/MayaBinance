using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using MayaBinance.Application;
using MayaBinance.Application.Configs;
using MayaBinance.Application.ModelMappers;
using MayaBinance.DataAccess.Context;
using MayaBinance.DataAccess.Infrastructures;
using MayaBinance.DataAccess.Repositories.BaseModels;
using MayaBinance.DataAccess.Repositories.BaseModels.Interfaces;
using MayaBinance.DataAccess.Repositories.Identity;
using MayaBinance.DataAccess.Repositories.Identity.Interfaces;
using MayaBinance.Domain.Identity.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MayaBinance.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = new DatabaseConnection
                {ConnectionString = Configuration["ReadConnectionString"]};
            services.AddDbContext<MayaBinanceContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"]);
            });
            services.AddSingleton(connectionString);
            services.AddAutoMapper(typeof(AutoMapperBase));
            services.AddMediatR(typeof(CQRS).GetTypeInfo().Assembly);
            services.AddTransient<IUnitOfWork, MayaBinanceContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining<CQRS>();
            });
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
                //etc
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
