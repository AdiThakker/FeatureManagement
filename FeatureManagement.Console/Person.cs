using FeatureManagement.Console.FeatureManagement;
using FeatureManagement.Console.FeatureManagement.Filters;
using FeatureManagement.Console.FeatureManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console
{
    [FeatureDefinition("VerboseLogging")]
    public class Person
    {
        private IFeatureFlagManagement featureManager;
        private string address;

        public string Name => "John Doe";

        public string Address
        {
            get => "123 Street";
            set => address = value;
        }

        public Person(IFeatureFlagManagement featureFlagManager) => featureManager = featureFlagManager;

        public async Task<string> Display() => await featureManager.IsFeatureEnabledAsync(this) switch
        {
            true => string.Concat("Verbose Logging enabled: ", Name, " - ", Address),
            _ => string.Concat("Verbose Logging disabled: ", Name)
        };

        public async Task<string> CustomDisplay() => await featureManager.IsFeatureEnabledAsync("CustomFilterVerboseLogging", this) switch
        {
            true => string.Concat("Verbose Logging enabled: ", Name, " - ", Address),
            _ => string.Concat("Verbose Logging disabled: ", Name)
        };
    }

}
