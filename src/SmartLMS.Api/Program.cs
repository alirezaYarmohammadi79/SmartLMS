using Microsoft.EntityFrameworkCore;
using SmartLMS.Api;
using SmartLMS.Api.Middleware;
using SmartLMS.Application;
using SmartLMS.Infrastructure;
using SmartLMS.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentaion();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();


var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment() is not true)
{
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
