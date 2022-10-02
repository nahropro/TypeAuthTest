using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TypeAuthTest.Data;
using TypeAuthTest.Repos;
using TypeAuthTest.Repos.Interfaces;
using TypeAuthTest.Services;
using TypeAuthTest.Services.Interfaces;

namespace TypeAuthTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<TypeAuthDbContext>(options =>
                options.UseSqlServer("Data Source=127.0.0.1; Initial Catalog=TypeAuth; Integrated Security=True"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT token",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                o.OperationFilter<SecurityRequirementsOperationFilter>();

                //o.SwaggerDoc("v1", new OpenApiInfo { Title = "SLB.Web", Version = "v1" });

                //string filePath = Path.Combine(AppContext.BaseDirectory, "SLB.Web.Server.xml");
                //o.IncludeXmlComments(filePath);

                //string filePath2 = Path.Combine(AppContext.BaseDirectory, "SLB.Shared.xml");
                //o.IncludeXmlComments(filePath2);
            });

            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IHashService, HashService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            var app = builder.Build();

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