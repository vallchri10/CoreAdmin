using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CorePractice.Data.DataSources;
using CorePractice.Data.DataServices.Abstract;
using CorePractice.Data.DataServices.Concrete;
using AutoMapper;
using CorePractice.Domain.Models;

namespace CorePractice.Api
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerEntity, Customer>();
            });

            services.AddSingleton(config.CreateMapper());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CoreContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("RigConnection")));

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddCors();
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

            app.UseCors(options => options.WithOrigins("https://localhost:44375").AllowAnyMethod());
            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseMvc();
        }
    }
}
