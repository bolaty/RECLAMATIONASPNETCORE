using Microsoft.Extensions.Configuration;
using MgRequeteClients.DAL;
using Microsoft.Extensions.DependencyInjection;
using MgRequeteClients.Tools.Classes;
using MgRequeteClients.API.Configuration;
using MgRequeteClients.API.Services;
using MgRequeteClients.API.Service;
using MgRequeteClients.API.ServiceContract;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;


Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Development");

var builder = WebApplication.CreateBuilder(args); //pour docker

// 1. Charger la configuration
var configuration = builder.Configuration;

////pour docker
//builder.Configuration
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//    .AddEnvironmentVariables();
////pour docker
///

//pour docker
// 1. Charger D'ABORD le JSON, PUIS les variables d'environnement
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables(); // Les variables écrasent le JSON

// Après avoir chargé la configuration:
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]
    .Replace("__DEFAULT_CONNECTION__",
        Environment.GetEnvironmentVariable("DEFAULT_CONNECTION") ?? string.Empty);

builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

// 2. Remplacer les variables pour ApiEndpoints
var apiEndpoints = builder.Configuration.GetSection("ApiEndpoints");
foreach (var endpoint in apiEndpoints.GetChildren())
{
    var value = endpoint.Value;
    if (!string.IsNullOrEmpty(value) && value.Contains("__"))
    {
        var envVarName = value.Trim('_');
        var envVarValue = Environment.GetEnvironmentVariable(envVarName) ?? string.Empty;
        builder.Configuration[$"ApiEndpoints:{endpoint.Key}"] = value.Replace($"__{envVarName}__", envVarValue);
    }
}


// 2. Ajouter les services
builder.Services.AddControllers(); //  Nécessaire pour détecter les contrôleurs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configuration custom
builder.Services.Configure<ApiEndpointsOptions>(
    builder.Configuration.GetSection("ApiEndpoints"));

builder.Services.AddScoped<ClientDAO>();
builder.Services.AddTransient<SmsService>();
clsDeclaration.InitialiserConfiguration(builder.Configuration);
builder.Services.AddScoped<IwsAgence, wsAgence>();
builder.Services.AddScoped<IRequeteClientsClasse, RequeteClientsClasse>();

var app = builder.Build();

// 4. Middleware
if (app.Environment.IsDevelopment())
{
    try
    {
        app.UseSwagger();
        app.UseSwaggerUI(); 
    }
    catch (Exception ex)
    {
        Console.WriteLine("Swagger config failed: " + ex.Message);
    }
   
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // pour accéder aux fichiers statiques
// 5. Ajouter le mappage des contrôleurs
app.UseAuthorization();
app.MapControllers(); //  Obligatoire pour que les endpoints soient reconnus

app.Run();
