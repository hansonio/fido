using Fido.Web.Configuration;
using Fido.Web.Data;
using Fido.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Fido.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddUserSecrets<Startup>()
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.Configure<AppSettings>( Configuration.GetSection("appSettings"));

            var connection = Configuration.GetConnectionString("fido.data");
            services.AddDbContext<ApplicationDataContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                    {
                        options.Cookies.ApplicationCookie.AccessDeniedPath = "/accessdenied";
                        options.Cookies.ApplicationCookie.LoginPath = "/login";
                        options.Cookies.ApplicationCookie.LogoutPath = "/logApplicationCookie";

                        options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents() {
                            OnRedirectToAccessDenied = context => {
                                if (context.Request.Path.StartsWithSegments("/api"))
                                {
                                    context.Response.StatusCode = 403;
                                    return Task.FromResult(0);
                                }

                                context.Response.Redirect(context.RedirectUri);
                                return Task.FromResult(0);

                            },
                            OnRedirectToLogin = context =>
                            {
                                if (context.Request.Path.StartsWithSegments("/api"))
                                {
                                    context.Response.StatusCode = 401;
                                    return Task.FromResult(0);
                                }

                                context.Response.Redirect(context.RedirectUri);
                                return Task.FromResult(0);
                            }
                        };
                    })
                    .AddEntityFrameworkStores<ApplicationDataContext, Guid>()
                    .AddDefaultTokenProviders();

            services.AddTransient<SeedData>();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureServices(services);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WalkFido API", Version = "v1" });

                //Set the comments path for the swagger json and ui.
                c.IncludeXmlComments(GetXmlCommentsPath(PlatformServices.Default.Application));
                c.DescribeAllEnumsAsStrings();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                
            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc();

            if (env.IsDevelopment())
            { 
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUi(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WalkFido API V1");
                });

            }

            app.Run( async (context) =>
            {
                await context.Response.WriteAsync("Hello! The route you were looking for was not handled by anybody else");
            });

            SeedData.Run(app.ApplicationServices).Wait();
        }

        private string GetXmlCommentsPath(ApplicationEnvironment appEnvironment)
        {
            return Path.Combine(appEnvironment.ApplicationBasePath, "FidoWeb.xml");
        }
    }
}
