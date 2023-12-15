using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using web.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddMvc().AddJsonOptions(O =>
{
    O.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

string conectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<IMDBContext>(config =>
{
    config.UseSqlServer(conectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();


app.UseSwaggerUI();

app.MapControllers();

app.Run();


