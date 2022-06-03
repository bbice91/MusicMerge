using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicMerge.Data;
using Azure.Identity;
using MusicMerge;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MusicMergeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicMergeContext") ?? throw new InvalidOperationException("Connection string 'MusicMergeContext' not found.")));


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); ;
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ^^ COnfigure Method in startup.cs
var app = builder.Build();
// VV  MIddleware, 




//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200")
   );

app.MapControllers();

app.Run();
