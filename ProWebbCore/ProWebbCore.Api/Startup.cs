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


namespace ProWebbCore.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql((_configuration.GetConnectionString("DatabaseConnectionString"))));
            
            services.AddAWSService<IAmazonS3>(_configuration.GetAWSOptions());
            services.AddSingleton<IBucketRepository, BucketRepository>();
            services.AddSingleton<IFilesRepository, FilesRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);



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

            // context.Database.Migrate(); // Not always needed

            app.UseMvc();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
