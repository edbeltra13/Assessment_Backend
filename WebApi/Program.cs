using Microsoft.EntityFrameworkCore;
using System;
using WebApi;
using WebApi.Contracts;
using WebApi.Domain;
using System.Globalization;

//CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
//CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure database connection
builder.Services.AddDbContext<WebApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register IUserService with a database-backed implementation
builder.Services.AddTransient<IUsers, UserService>();
//builder.Services.AddTransient<UserService>(new UserService());

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
