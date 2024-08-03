using ElectronicRealPropertyTaxUnisan.Services;
using ElectronicRealPropertyTaxUnisan.Repositories.Interfaces;
using ElectronicRealPropertyTaxUnisan.Repositories;
using ElectronicRealPropertyTaxUnisan.Services.Interfaces;
using Dapper;
using System.Data;

DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDatabaseConnection, PostgreSqlConnection>();
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var dbConnection = sp.GetRequiredService<IDatabaseConnection>();
    var connection = dbConnection.CreateConnection();
    connection.Open();
    return connection;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
