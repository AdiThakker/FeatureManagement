using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace FeatureManagement.Console.FeatureManagement.Filters
{
    public class PersonAddressFilter : IContextualFeatureFilter<Person>
    {        
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, Person appContext)
        {
            _ = featureFilterContext ?? throw new ArgumentNullException(nameof(featureFilterContext));
            _ = appContext ?? throw new ArgumentNullException(nameof(appContext));

            var printAddressFilterConfig = featureFilterContext.Parameters.Get<Person>();
            if(printAddressFilterConfig != null)
            {
                return Task.FromResult(string.Equals(printAddressFilterConfig.Address, appContext.Address, StringComparison.InvariantCultureIgnoreCase));
            }

            return Task.FromResult(false);
        }
    }
}
