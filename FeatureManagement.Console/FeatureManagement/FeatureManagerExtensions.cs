using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using System.Diagnostics;

namespace FeatureManagement.Console.FeatureManagement
{
    public static class FeatureManagerExtensions
    {
        public static IServiceCollection AddFeatureConfiguration(this IServiceCollection collection)
        {
            collection.AddFeatureManagement().AddFeatureFilter<TimeWindowFilter>();
            return collection;
        }
    }
}
