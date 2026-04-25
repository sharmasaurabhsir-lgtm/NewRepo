using Microsoft.EntityFrameworkCore;
using PaymentPortal.Data;
using PaymentPortal.Repositories;
using PaymentPortal.Services;

var builder = WebApplication.CreateBuilder(args);

//Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("PaymentAppConnection");

//Register DbContext with SQL Server     
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
  {
        policy.WithOrigins("http://localhost:55932", "http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

//Dependency Injection
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Use CORS middleware (must be before MapControllers)
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
