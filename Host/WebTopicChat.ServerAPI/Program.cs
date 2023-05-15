using WebTopicChat.Infrastructure.DependencyInjection;
using WebTopicChat.Infrastructure.Extensions.AutoMapper.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureAutoMapper();

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
