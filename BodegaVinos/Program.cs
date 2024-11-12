
using BodegaVinos.Data;
using BodegaVinos.Data.Repository;
using BodegaVinos.Services.Implementations;
using BodegaVinos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos
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

            builder.Services.AddDbContext<BodegaDbContext>(dbContextOptions => dbContextOptions.UseSqlite(
            builder.Configuration["ConnectionStrings:DBConnectionString"]));
            #region DependencyInjection
            builder.Services.AddScoped<IWineRepository, WineRepository>();
            builder.Services.AddScoped<IWineService, WineService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion
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
