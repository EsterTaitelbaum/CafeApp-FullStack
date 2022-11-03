using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Project1
{
    public class Startup
    {
        ILogger<Startup> _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<ICategoryDL, CategoryDL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<IProductDL, ProductDL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IOrderDL, OrderDL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IRatingDL, RatingDL>();
            services.AddScoped<IRatingBL, RatingBL>();
            services.AddScoped<IComplaintDL, ComplaintDL>();
            services.AddScoped<IComplaintBL, ComplaintBL>();
            services.AddDbContext<CoffeeShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Coffee Shop")));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            app.UseErrorMiddleware();

            _logger = logger;
            _logger.LogInformation("the application came up");
            
            

            app.UseRouting();



            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });




            app.UseHttpsRedirection();


            app.Map("/api", app2 =>
            {
                app2.UseRouting();
                app2.UseRatingMiddleware();
                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });


            app.UseAuthorization();

        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           

        }
    }
}
