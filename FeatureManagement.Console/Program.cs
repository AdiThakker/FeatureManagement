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
        services.AddFeatureConfiguration(_ => _.AddFeatureFilter<AddressFilter>());
        services.AddTransient<IFeatureFlagManagement, FeatureFlagManagement>();

    })
    .Build();

// Time Window logging feature
var person = new Person();
Console.WriteLine(await person.Display(app.Services.GetService<IFeatureFlagManagement>()!));

// Custom Filter logging feature
Console.WriteLine(await person.CustomDisplay(app.Services.GetService<IFeatureFlagManagement>()!));

person.Address = "Famous Street";
Console.WriteLine(await person.CustomDisplay(app.Services.GetService<IFeatureFlagManagement>()!));

app.Run();