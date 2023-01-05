// See https://aka.ms/new-console-template for more information
using FeatureManagement.Console;
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
        services.AddFeatureConfiguration();
        services.AddTransient<IFeatureFlagManagement, FeatureFlagManagement>();

    })
    .Build();


Console.WriteLine(await new Person(app.Services.GetService<IFeatureFlagManagement>()).Display());

app.Run();