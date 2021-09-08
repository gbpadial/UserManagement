using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Core.Http;
using UserManagement.Data.Services;
using UserManagement.Domain;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Domain.Services;
using UserManagement.Domain.Validations;
using UserManagement.Infra.Repositories.Users;
using UserManagement.Data.Handlers;

namespace UserManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("UserManagement", null));
            services.AddScoped<ICepService, ViaCepService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IHttpHandler, HttpClientHandler>();
            services.AddMvc().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<ApiContext>());
            services.AddMediatR(this.GetType().Assembly, typeof(ApiContext).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(ApiContext).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
