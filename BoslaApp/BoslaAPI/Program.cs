
using BoslaAPI.Data;
using Python.Runtime;

namespace BoslaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(option =>
            {
                option.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add Application DB Context
            builder.Services.AddDbContext<BoslaDbContext>();


            // Initialize Python Engine (Load Only Once)
            Runtime.PythonDLL = "C:\\Users\\BnAdel\\AppData\\Local\\Programs\\Python\\Python38\\python38.dll";


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
