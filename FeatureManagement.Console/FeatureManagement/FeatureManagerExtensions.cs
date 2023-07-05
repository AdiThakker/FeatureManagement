using FeatureManagement.Console.FeatureManagement.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using System.Diagnostics;

namespace FeatureManagement.Console.FeatureManagement
{
    public static class FeatureManagerExtensions
    {
        public static IServiceCollection AddFeatureConfiguration(this IServiceCollection collection, Action<IFeatureManagementBuilder> addFeatureFilters = null)
        {
            var featureBuilder = collection.AddFeatureManagement().AddFeatureFilter<TimeWindowFilter>();

            // add additional feature filters if any
            addFeatureFilters?.Invoke(featureBuilder);

            return collection;
        }
    }
}
