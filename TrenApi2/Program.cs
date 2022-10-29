using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//Add services to the container.

builder.Services.AddTransient<IRezervationDetailDal, RezervationDetailDal>();
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
