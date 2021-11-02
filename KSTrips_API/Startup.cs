using KSTrips.Application.Interfaces;
using KSTrips.Application.Services;
using KSTrips.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;



namespace KSTrips_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        ///     Startup
        /// </summary>
        /// <param name="env"></param>
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", true, true)
                          .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set default authentication scheme
            services.AddAuthentication(options =>
                                        {
                                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                        });

            //// Configure API authentication options and Swagger support
            ConfigureApiAuthentication(services);

            //// Configure JWT Bearer Token authentication options and Swagger support
            ConfigureJwtAuthentication(services);

            //Inject HealthCheck
            var connectionString = Configuration["TripContextDev"];
            services.AddHealthChecks()
                    .AddSqlServer(connectionString, failureStatus: HealthStatus.Unhealthy);

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", 
                    options => options.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            //services.AddDbContext<TripContext>(options => options.UseSqlServer(Configuration["TripContext"]));
            services.AddDbContext<TripContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc()
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });

            services.AddMvc(opt => opt.EnableEndpointRouting = false);


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISimulationService, SimulationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IEmailService, EmailService>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KSTrips API", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TripContext context)
        {
            app.UseCors("AllowOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "KSTrips_API Swagger UI";
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint(Configuration.GetValue<string>("SwaggerEndpoint"), "KSTrips API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc();



            //Use EndPoint for healthChecks, and filter ready or live Status
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = WriteHealthCheckResponse,
                    AllowCachingResponses = false,
                    ResultStatusCodes =
                                     {
                                         [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                                         [HealthStatus.Healthy] = StatusCodes.Status200OK,
                                         [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                                     }
                });
            });

        }

        /// <summary>
        ///     Custom Response for health Checks
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("OverallStatus", result.Status.ToString()),
                new JProperty("TotalChecksDuration", result.TotalDuration.TotalSeconds.ToString("0:0.00")),
                new JProperty("DependencyHealthChecks", new JObject(result.Entries.Select(dicItem =>
                                                                                              new JProperty(dicItem.Key, new JObject(
                                                                                                  new JProperty("Status", dicItem.Value.Status.ToString()),
                                                                                                  new JProperty("Duration", dicItem.Value.Duration.TotalSeconds.ToString("0:0.00")),
                                                                                                  new JProperty("Exception", dicItem.Value.Exception?.Message),
                                                                                                  new JProperty("Data", new JObject(dicItem.Value.Data.Select(dicData =>
                                                                                                                                                                  new JProperty(dicData.Key, dicData.Value))))
                                                                                              ))
                )))
            );

            return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
        }

        /// <summary>
        ///     Configure JWT Authentication and add Swagger support
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            // Configure JWT authentication
            var key = Encoding.ASCII.GetBytes(
                Configuration.GetValue<string>("JWT:EncriptionKey"));

            services.AddAuthentication()
                    .AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateAudience = false,
                            ValidateIssuer = false,
                            ValidateIssuerSigningKey = false,
                            ValidateLifetime = true
                        };
                    });

            // Enable Swagger JWT authentication
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",

                    // Retrieve a valid test token from: /Users/UserName/mdresser@genexservicesdev.onmicrosoft.com
                    Description = "JWT Bearer Token. Format: \"Bearer encodedheader.encodedpayload.encodedsignature\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                       {
                                           {
                                               new OpenApiSecurityScheme
                                               {
                                                   Reference = new OpenApiReference
                                                   {
                                                       Id = "Bearer",
                                                       Type = ReferenceType.SecurityScheme
                                                   }
                                               },
                                               new string[] { }
                                           }
                                       });
            });
        }

        /// <summary>
        ///     Configure API Authentication and add Swagger support
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureApiAuthentication(IServiceCollection services)
        {
            //services.AddAuthentication()
            //        .AddApiKeySupport(options =>
            //        {
            //        });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("apikey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Query,
                    Name = "api_key",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "apikey"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                       {
                                           {
                                               new OpenApiSecurityScheme
                                               {
                                                   In = ParameterLocation.Query,
                                                   Name = "apikey",
                                                   Reference = new OpenApiReference
                                                   {
                                                       Id = "apikey",
                                                       Type = ReferenceType.SecurityScheme
                                                   }
                                               },
                                               new List<string>()
                                           }
                                       });
            });
        }
    }
}
