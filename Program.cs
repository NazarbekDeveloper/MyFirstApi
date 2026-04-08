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
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
