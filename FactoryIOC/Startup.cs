using FactoryIOC.Factory;
using FactoryIOC.Service;
using FactoryIOC.Shapes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryIOC
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
            services.AddTransient<IShapeFactory, ShapeFactory>();

            services.AddTransient<IShapeCalculationService, ShapeCalculationService>();

            services.AddScoped<SphereShape>();
            services.AddScoped<IShape, SphereShape>(s => s.GetService<SphereShape>());

            services.AddScoped<CubeShape>();
            services.AddScoped<IShape, CubeShape>(s => s.GetService<CubeShape>());

            services.AddScoped<IRandomService, RandomService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
