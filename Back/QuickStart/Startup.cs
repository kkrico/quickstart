using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickStart.Web.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace QuickStart.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMemoryCache();
            services.AddMediatR(typeof(Startup));

            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });


            services.AddSwaggerGen(s =>
            {
                Info info = GetSwaggerInfoFrom(Configuration);
                s.SwaggerDoc(info.Version, info);
            });

            return services.AsAutoFacServiceProvider();
        }

        private Info GetSwaggerInfoFrom(IConfiguration configuration)
        {
            return configuration.GetSection(nameof(Info))
                       ?.Get<Info>() ?? throw new InvalidOperationException("Não é possivel iniciar o projeto sem" +
                                                                            "configurar Swagger");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    Info info = GetSwaggerInfoFrom(Configuration);
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", info.Description);
                });

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}