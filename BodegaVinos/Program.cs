
using BodegaVinos.Data;
using BodegaVinos.Data.Repository;
using BodegaVinos.Services.Implementations;
using BodegaVinos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            builder.Services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("BodegaVinos", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Acá pegar el token generado al loguearse."
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "BodegaVinos" 
                                } //Tiene que coincidir con el id seteado arriba en la definición
                        }, new List<string>() 
                    }
                });
            });
            builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticación que tenemos que elegir después en PostMan para pasarle el token
    .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);


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
