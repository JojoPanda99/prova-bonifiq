using Microsoft.EntityFrameworkCore;
using ProvaPub.Configuration;
using ProvaPub.Repository;
using ProvaPub.Services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.UseSwaggerConfig();
builder.Services.AddDependencyInjectionConfig();

builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ctx")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseSwaggerConfig();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();