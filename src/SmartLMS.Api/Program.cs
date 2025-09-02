using SmartLMS.Api;
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
