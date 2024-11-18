using CommerceApp.Persistence;
using CommerceApp.Application;
using CommerceApp.Mapper;
using CommerceApp.Application.Exceptions;
using CommerceApp.Infrastructure;
using Microsoft.OpenApi.Models;


namespace CommerceApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddCustomMapper();

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo() { Title = "CommerceApp", Version = "v1", Description = "CommerceApp v1 Swagger UI" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
                    }
                });
            });


            var app = builder.Build();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
