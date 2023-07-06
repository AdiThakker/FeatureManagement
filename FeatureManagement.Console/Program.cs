// See https://aka.ms/new-console-template for more information
using FeatureManagement;
using FeatureManagement.Console;
using FeatureManagement.Console.FeatureManagement;
using FeatureManagement.Console.FeatureManagement.Filters;
using FeatureManagement.Console.FeatureManagement.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, Feature Management!!");

var app = Host.CreateDefaultBuilder()
    .ConfigureLogging((loggingBuilder) =>
    {
        loggingBuilder.AddConsole();
    })
    .ConfigureServices(services =>
    {
        services.AddFeatureConfiguration(_ => _.AddFeatureFilter<PersonAddressFilter>());
        services.AddTransient<IFeatureFlagManagement, FeatureFlagManagement>();

    })
    .Build();

var featureManager = app.Services.GetService<IFeatureFlagManagement>()!;

// Time Window logging feature
var person = new Person();
Console.WriteLine(await person.Display(featureManager));

// Address logging feature (disabled)
Console.WriteLine(await person.CustomDisplay(featureManager));

// Address logging feature (enabled)
person.Address = "Famous Street";
Console.WriteLine(await person.CustomDisplay(featureManager));

app.Run();