
using EmployeeManagementBackened.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeManagementBackened
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EmployeeContext>(Options =>
            Options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeMgmMINIDB"))
            );


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => { 
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

            });
            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}