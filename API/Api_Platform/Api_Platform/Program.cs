using System.Text;
using Contracts;
using Insfrastructur;
using Insfrastructur.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddDbContext<AppDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("Platform")));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
//app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
