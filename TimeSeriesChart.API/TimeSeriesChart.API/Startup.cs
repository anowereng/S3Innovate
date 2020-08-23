using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeSeriesChart.Data.Contexts;
using TimeSeriesChart.Data.Repository;
using TimeSeriesChart.Data.services;
using TimeSeriesChart.Data.UnitOfWork;

namespace TimeSeriesChart.API
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
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            var connstring = Configuration.GetConnectionString("DefaultConnection");

            services.
                         /*For Defendency another assembly */
                         AddTransient<TimeseriesContext>(x => new TimeseriesContext(connstring, migrationAssemblyName)).
                         AddTransient<TimeSeriesChartUnitOfWork>(x => new TimeSeriesChartUnitOfWork(connstring, migrationAssemblyName));
            /* For migraion */
            services.AddDbContext<TimeseriesContext>(x => x.UseSqlServer(connstring, m => m.MigrationsAssembly(migrationAssemblyName)));
            /*For Repository and services*/
            services.
                     AddTransient<IBuildingRepository, BuildingRepository>().
                     AddTransient<IDataFieldRepository, DataFieldRepository>().
                     AddTransient<IObjectItemRepository, ObjectItemRepository>().
                     AddTransient<IBuildingService, BuildingService>().
                     AddTransient<IDataFieldService, DataFieldService>().
                     AddTransient<IObjectItemService, ObjectItemService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                   builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           var connection =   Configuration.GetConnectionString("DefaultConnection");
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            Seed.Initialize(connection, migrationAssemblyName).Wait();

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
