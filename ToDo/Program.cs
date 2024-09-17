using Microsoft.EntityFrameworkCore;
using ToDo.DataContexts;
using ToDo.Repositories;
using ToDo.Services;
using ToDo.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Databases
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TODO_DB"));

// Add Services
builder.Services.AddScoped<TaskItemService>();

// Add Repository
builder.Services.AddScoped<TaskItemReadRepository>();

// Add Utilities
builder.Services.AddScoped<TimeMachine>();

// Add Test Seed Data
builder.Services.AddHostedService<AppDbContextSeedDataTest>();

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
