using System.Text.Json;
using System.Text.Json.Serialization;
using Morali.Application;
using Morali.Extensions;
using Morali.Infrastructure;
using Morali.Middlewares;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Morali;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAPI()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();