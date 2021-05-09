using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Schedule.Data.Context;
using Schedule.Data.SqlServer;
using Schedule.Domain;
using Schedule.Domain.AutoMap;
using Schedule.Service;
using FluentValidation.AspNetCore;
using Schedule.Domain.Models;
using FluentValidation;
using Schedule.Domain.Validations;
using Schedule.Domain.Notification;

namespace Schedule.Api.Application
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

            //services.AddTransient<RequestAnimalDtoValidate>();

            services.AddControllers().AddValidations();         

            #region Swegger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Schedule.Api.Application", Version = "v1" });
            });
            #endregion

            #region Database
            services.AddSqlServer(Configuration);
            #endregion

            #region AutoMapper
            services.ConfigureAutoMapper();
            #endregion

            #region Services
            services.AddServices();
            #endregion

            #region Notification
            services.AddScoped<INotificationHandler, NotificationHandler>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule.Api.Application v1");
                    c.RoutePrefix = string.Empty;
                });
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Migrate
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dataContext = serviceScope.ServiceProvider.GetService<ScheduleContext>();
                dataContext.Database.Migrate();
            }
            #endregion
        }
    }
}
