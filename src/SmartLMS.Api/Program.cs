using SmartLMS.Api;
using SmartLMS.Api.Middleware;
using SmartLMS.Application;
using SmartLMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentaion();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

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
