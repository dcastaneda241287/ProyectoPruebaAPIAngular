using APIPrueba.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace APIPrueba
{
    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        //private static IConfiguration Configuration { get; }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            //IConfiguration configuration;
            //configuration = Configuration;

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIPrueba", Version = "v1" });
            });

            builder.Services.AddDbContext<PaymentDetailContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddCors();
        }
        private static void Configure(WebApplication app)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIPrueba"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            
        }
    }
}
