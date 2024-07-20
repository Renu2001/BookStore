using BusinessLayer.Interface;
using BusinessLayer.Service;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.CQRS.Handlers.User;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using RepositoryLayer.Utility;
using System.Reflection;
using System.Text;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(typeof(CreateUserHandler).Assembly);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<BookStoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = builder.Configuration["Jwt:Issuer"],
                   ValidAudience = builder.Configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
               };
           });



            builder.Services.AddScoped<IUserRL, UserRL>();
            builder.Services.AddScoped<IUserBL, UserBL>();
            builder.Services.AddScoped<IBookRL, BookRL>();
            builder.Services.AddScoped<IBookBL, BookBL>();
            builder.Services.AddScoped<ICartRL, CartRL>();
            builder.Services.AddScoped<ICartBL, CartBL>();
            builder.Services.AddScoped<ICustomerDetailsRL, CustomerDetailsRL>();
            builder.Services.AddScoped<ICustomerDetailsBL, CustomerDetailsBL>();
            builder.Services.AddScoped<IOrderRL, OrderRL>();
            builder.Services.AddScoped<IOrderBL, OrderBL>();
            builder.Services.AddScoped<IWishListRL, WishListRL>();
            builder.Services.AddScoped<IWishListBL, WishListBL>();
            builder.Services.AddScoped<Token>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Book_Store API",
                    Version = "v1"
                });

                // Add Bearer token authentication
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please enter a valid token"
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                        {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                              Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
