using Microsoft.EntityFrameworkCore;
using cSharpApi.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<MyFirstAPIDBContext>();
//new
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //new
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
