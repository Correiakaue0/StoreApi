using Serilog;
using Store.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Add & Configure Serilog para Log
builder.Services.AddSerilog();
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IOC Inversion of Control - Dependency Injection
builder.Services.AddDependencyInjection();

//Configuration Authentication Jwt
builder.Services.AddJwtAuthentication();

//Configuration Swagger
builder.Services.AddSwaggerConfiguration();

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
