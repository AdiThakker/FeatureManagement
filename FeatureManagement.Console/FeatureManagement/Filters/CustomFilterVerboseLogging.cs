using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console.FeatureManagement.Filters
{
    public class CustomFilterVerboseLogging : IContextualFeatureFilter<Person>
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
