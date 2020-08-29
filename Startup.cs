using AutoMapper;
using CommanderApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace CommanderApi
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
            services.AddDbContext<CommanderContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CommanderDbConnectionString")));

            // Force system to accept only the JSON Properties that match the setting
            services.AddControllers()
                    .AddNewtonsoftJson(s => { s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });

            // DI
            /*
            * Service LifeTime
            * AddSingleton = Same object for every request
            * AddScoped = Object created once per client request
            * Transient = New object instance created every time 
            */
            // services.AddScoped<ICommanderRespository, MockCommanderRepository>();
            services.AddScoped<ICommanderRepository, SqlCommanderRepository>();

            // Register AutoMapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
