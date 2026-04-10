using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

namespace MyFirstApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddTransient<Data.ApplicationDbContext>();
            builder.Services.AddTransient<Repositories.IEmployeeRepository, Repositories.EmployeeRepository>();
            builder.Services.AddTransient<Services.IEmployeeService, Services.EmployeeService>();
            builder.Services.AddTransient<Repositories.IProductRepository, Repositories.ProductRepository>();
            builder.Services.AddTransient<Services.IProductService, Services.ProductService>();
            builder.Services.AddOpenApi();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); // OpenAPI hujjatini generatsiya qilish
                app.MapScalarApiReference(); // Scalar interfeysini ochish
            }

            app.MapControllers();

            app.Run();
        }
    }
}
