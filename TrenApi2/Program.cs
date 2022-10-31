 using Business.Abstract;
using Business.Concrete;
using Core.Abstract;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//Add services to the container.

builder.Services.AddTransient<IRezervationDetailService, RezervationDetailManager>();


builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
