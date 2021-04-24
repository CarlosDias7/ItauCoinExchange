using Itau.CoinExchange.Api.Filters;
using Itau.CoinExchange.DependenciesInjections;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Itau.CoinExchange.Api
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
            services.AddControllers();
            services
                .AddMvc(m =>
                {
                    m.EnableEndpointRouting = false;
                    m.Filters.Add<NotificationFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Itaú - Desafio técnico",
                        Description = "Serviço de conversão de moedas estrangeiras por segmento.",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Carlos Dias",
                            Url = new Uri("https://github.com/CarlosDias7")
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.UseItauExchangeDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc().UseApiVersioning();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    x.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseRequestLocalization(new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture("pt-BR") });
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
        }
    }
}