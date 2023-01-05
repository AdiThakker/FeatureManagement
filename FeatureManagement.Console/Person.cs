using FeatureManagement.Console.FeatureManagement;
using FeatureManagement.Console.FeatureManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console
{
    [FeatureDefinition("VerboseLogging")]
    public class Person
    {
        private IFeatureFlagManagement featureManager;

        public string Name => "John Doe";

        public string Address => "123 Street";

        public Person(IFeatureFlagManagement featureFlagManager) => featureManager = featureFlagManager;

        public async Task<string> Display() => await featureManager.IsFeatureEnabledAsync(this) switch
        {
            true => string.Concat(Name , " ", Address),
            _ => Name,
        };
    }

}
