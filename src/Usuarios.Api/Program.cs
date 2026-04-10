using Usuarios.Adapters.Repositories;
using Usuarios.Api.Endpoints;
using Usuarios.Application.Services;
using Usuarios.Domain.Ports;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    // Specify the OpenAPI version to use
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.MapOpenApi("/openapi/{documentName}.yaml");

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthEndpoints();
app.MapUserEndpoints();

await app.RunAsync();

public partial class Program
{
    protected Program()
    {
    }
}
