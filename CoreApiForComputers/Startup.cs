using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CoreApiForComputers.Authentication;
using CoreApiForComputers.DataBase;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CoreApiForComputers
{
    /// <summary>
    /// Contains methods ConfigureServices() and Configure() that are called
    /// by the ASP.NET Core runtime when the app starts
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Services are registered in ConfigureServices and consumed across the app 
        /// via dependency injection (DI) or ApplicationServices.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataModelsConfiguration();

            services.AddMvc(
                setup =>
                {
                    setup.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                    setup.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                    setup.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                    setup.Filters.Add(
                        new ProducesDefaultResponseTypeAttribute());
                    setup.Filters.Add(
                        new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));

                    setup.Filters.Add(
                        new AuthorizeFilter());


                    setup.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    setup.EnableEndpointRouting = false;
                });

            services.AddVersionedApiExplorer(setupAction =>
            {
                setupAction.GroupNameFormat = "'v'VV";
            });

            services.AddAuthentication("Basic")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

            services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            var apiVersionDescriptionProvider =
               services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(setupAction =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setupAction.SwaggerDoc(
                    $"CoreApiForComputers{description.GroupName}",
                    new OpenApiInfo()
                    {
                        Title = "Computers API",
                        Version = description.ApiVersion.ToString(),
                        Description = "Through this API you can access parts and computers.",
                        Contact = new OpenApiContact()
                        {
                            Email = "radoslaw.lukasz.zegzula@gmail.com",
                            Name = "Rados³aw Zegzu³a"
                        },
                    });

                }

                setupAction.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Description = "Input your username and password to access this API"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basicAuth" }
                        }, new List<string>() }
                });

                setupAction.DocInclusionPredicate((documentName, apiDescription) =>
                {
                    var actionApiVersionModel = apiDescription.ActionDescriptor
                    .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                        $"CoreApiForComputersv{v}" == documentName);
                    }
                    return actionApiVersionModel.ImplementedApiVersions.Any(v =>
                        $"CoreApiForComputers{v}" == documentName);
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
          

        }


        /// <summary>
        /// This method gets called by the runtime and is used 
        /// to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="apiVersionDescriptionProvider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setup.SwaggerEndpoint($"/swagger/" +
                        $"CoreApiForComputers{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
                setup.RoutePrefix = "";
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
