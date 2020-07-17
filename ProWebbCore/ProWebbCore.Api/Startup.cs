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
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = Configuration.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql(_configuration.GetConnectionString("DatabaseConnectionString"), 
                providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddAWSService<IAmazonS3>(_configuration.GetAWSOptions());
            services.AddSingleton<IBucketRepository, BucketRepository>();
            services.AddSingleton<IFilesRepository, FilesRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);



            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins(_configuration["ClientString"])
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                              });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // context.Database.Migrate(); // Not always needed

            app.UseCors(MyAllowSpecificOrigins);
            
            app.UseMvc();

            app.UseRouting();


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
