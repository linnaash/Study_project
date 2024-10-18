using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;
using System.Reflection;

namespace Cultura
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<Cultura_bdContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("DataAccess")));




            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Культурный центр API",
                    Description = "API для управления сотрудниками, отделами и мероприятиями культурного центра. Предоставляет функционал для создания," +
                    "обновления, удаления и получения данных.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Администрация культурного центра",
                        Url = new Uri("https://cultura.com/contact")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {

                        Name = "Лицензия на использование API",
                        Url = new Uri("https://cultura.com/license")

                    }
                });

            
             var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
             options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            
            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context=services.GetRequiredService<Cultura_bdContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
