using Microsoft.EntityFrameworkCore;
using src.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Add service context db config in DatabaseContext
builder.Services
.AddDbContext<DatabaseContext>(
    o => o
    .UseInMemoryDatabase("dbContracts")
);

//new object, return new instance DatabaseContext
builder.Services
.AddScoped<DatabaseContext, DatabaseContext>();

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
