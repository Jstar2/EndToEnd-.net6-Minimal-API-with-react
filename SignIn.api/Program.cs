using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.Data.Data;
using Project.Data.Model;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("ShopDbConnection");
builder.Services.AddDbContext<ShopDbContext>(options => {
    options.UseSqlServer(connection);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// this Allow the policy to run
app.UseCors("AllowAll");


ShopDbContext _shopDbContext;

app.MapGet("/GetCustomer", () => 
{

    return _shopDbContext.Set<Customers>().ToList();
});

app.Run();
