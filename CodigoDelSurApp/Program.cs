using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CodigoDelSurApp.Persistence;
using CodigoDelSurApp.Persistence.Repositories.Interface;
using CodigoDelSurApp.Persistence.Repositories;
using Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CodigoDelSurDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<TokenGeneratorHelper>();
builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IPotterService, PotterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPotterRepository, PotterRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Add JWT authentication
builder.Services.AddAuthentication(config => 
    {
        config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!)),
        };
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
