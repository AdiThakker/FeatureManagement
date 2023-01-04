// See https://aka.ms/new-console-template for more information
using FeatureManagement.Console;
using FeatureManagement.Console.Entity;
using FeatureManagement.Console.FeatureManagement;
using FeatureManagement.Console.FeatureManagement.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

Console.WriteLine("Hello, Feature Management!!");

var app = Host.CreateDefaultBuilder()
    .ConfigureLogging((loggingBuilder) =>
    {
        loggingBuilder.AddConsole();
    })
    .ConfigureServices(services =>
    {
        services.AddFeatureManagement();
        services.AddTransient<IFeatureFlagManagement, FeatureFlagManagement>();
    })
    .Build();


Person person = new("Adi", "Unkown");    

app.Run();