using System.Reflection;
using AutoMapper;
using MediatR;
using Pemex.Foss.HashidsDemo.Api.Core.Features;
using Pemex.Foss.HashidsDemo.Api.Core.Model;
using Pemex.Foss.HashidsDemo.Api.Core.Util;
using Pemex.Foss.HashidsDemo.Api.Infrastructure.Database;
using Pemex.Foss.HashidsDemo.Api.Infrastructure.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IHasher, Hasher>();

builder.Services
    .AddSingleton(serviceProvider =>
    {
        var mapperConfiguration = new MapperConfiguration(config =>
        {
            var hasher = serviceProvider.GetRequiredService<IHasher>();
            config.AddProfile(new EmpleadoMapping(hasher));
        });
        return mapperConfiguration.CreateMapper();
    });

builder.Services.AddTransient<IEmpleadoRepository>(serviceProvider => new EmpleadoRepository());

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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