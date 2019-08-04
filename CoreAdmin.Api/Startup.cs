using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CoreAdmin.Repository;
using CoreAdmin.Repository.Abstract;
using CoreAdmin.Repository.Concrete;

using AutoMapper;
using CoreAdmin.Api.Middleware;
using CoreAdmin.Domain.DataModels;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace CoreAdmin.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper();

            services
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddDbContext<CoreContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("RigConnection")));

            services
                .AddCors();

            services
                .AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseCors(options => options.WithOrigins("https://localhost:44375").AllowAnyMethod());

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMiddleware<ExceptionMiddleware>();




            app.UseMvc();
        }
    }
}
