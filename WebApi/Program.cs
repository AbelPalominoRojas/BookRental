using Application.Services.Abstractions;
using Application.Services.Implementations;
using Infrastructure.Context;
using Infrastructure.Repositories.Abstractions;
using Infrastructure.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data base context
builder.Services.AddDbContext<ApplicationDbContext>();

// DI
builder.Services.AddScoped<IEditorialRepository, EditorialRepository>();

builder.Services.AddScoped<IEditorialService, EditorialService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

