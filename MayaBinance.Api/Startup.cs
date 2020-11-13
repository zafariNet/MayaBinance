using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FluentValidation.AspNetCore;
using MayaBinance.Application;
using MayaBinance.Application.Configs;
using MayaBinance.DataAccess.Context;
using MayaBinance.DataAccess.Repositories.Identity;
using MayaBinance.Domain.Identity.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            services.AddMediatR(typeof(CQRS).GetTypeInfo().Assembly);
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers().AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining<CQRS>();
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
