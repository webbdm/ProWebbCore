using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProWebbCore.Api.Models;
using ProWebbCore.Infrastructure.Repositories;
using ProWebbCore.Infrastructure.Communication.Interfaces;
using Amazon.S3;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;

namespace ProWebbCore.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = Configuration.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  // This doesn't work
                                  // There's possibly an issue with .NET Core CORS middleware
                                  builder.WithOrigins(_configuration["ClientString"])
                                                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                                                    .AllowCredentials()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader();
                              });
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContext<AppDbContext>(options => options.UseMySql(_configuration.GetConnectionString("DatabaseConnectionString"), 
                providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddAWSService<IAmazonS3>(_configuration.GetAWSOptions());
            services.AddSingleton<IBucketRepository, BucketRepository>();
            services.AddSingleton<IFilesRepository, FilesRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // context.Database.Migrate(); // Not always needed

            app.UseHttpsRedirection();
            app.UseRouting();

            // app.UseCors(MyAllowSpecificOrigins); 

            // Use this for now as the above still throws CORS errors
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("ProWebbCore");
                });

                endpoints.MapControllers();
            });
        }
    }
}
