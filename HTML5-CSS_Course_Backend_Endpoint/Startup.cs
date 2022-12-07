using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using HTML5_CSS_Course_Backend_Logic;
using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Repository;
using HTML5_CSS_Course_Backend_Repository.Database;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace HTML5_CSS_Course_Backend_Endpoint
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ReservationContext>();

            services.AddTransient<IRepository<Reservation>, ReservationRepository>();
            services.AddTransient<IRepository<Table>, TableRepository>();
  

            services.AddTransient<IReservationLogic, ReservationLogic>();
            services.AddTransient<ITableLogic, TableLogic>();

            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "HTML5_CSS_Course_Backend_Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
               app.UseSwagger();
               app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HTML5_CSS_Course_Backend_Endpoint v1"));
            }
            
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>();
                Exception[] errors = { exception!.Error };
                var response = new ApiError(exception.Path, exception.Error.Message, errors);
                context.Response.StatusCode = GetStatusCode(exception.Error);
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static int GetStatusCode(Exception e)
        {
            if (e is ValidationException) return 400;
            else if (e is ExpiredTokenException) return 401;
            else if (e is AuthorizationException) return 403;
            else if (e is AuthenticationException) return 302;
            else if (e is NullReferenceException || e is ArgumentException || e is QuerryFailedException) return 500;
            return 404;
        }
    }        
}
