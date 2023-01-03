// See https://aka.ms/new-console-template for more information
using FeatureManagement.Console;
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
        services.AddSingleton(typeof(Outer));
        services.AddSingleton(typeof(Inner));
        services.AddSingleton(typeof(Helper));
    })
    .Build();


var outer = (Outer)app.Services.GetService(typeof(Outer));
var inner = (Inner)app.Services.GetService(typeof(Inner));
var helper = (Helper)app.Services.GetService(typeof(Helper));

outer.Log("Hello!");


outer.Log(() =>
{
    helper.Log("I am in Helper");
});

app.Run();