using Microsoft.EntityFrameworkCore;
using WheelzyChallenge.Domain.Interfaces;
using WheelzyChallenge.Infrastructure.Persistence;
using WheelzyChallenge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WheelzyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(WheelzyChallenge.Application.UseCases.Cars.GetCarById.Queries.GetCarByIdQuery).Assembly)
);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WheelzyDbContext>();
    WheelzyDbSeeder.Seed(db);
}

app.Run();
