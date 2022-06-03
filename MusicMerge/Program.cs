using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicMerge.Data;
using Azure.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MusicMergeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicMergeContext") ?? throw new InvalidOperationException("Connection string 'MusicMergeContext' not found.")));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MusicMerge", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();

    });
});

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
app.UseCors("MusicMerge");
app.MapControllers();

app.Run();
