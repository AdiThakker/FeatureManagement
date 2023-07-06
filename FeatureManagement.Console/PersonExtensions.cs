using FeatureManagement.Console.FeatureManagement.Interfaces;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeatureManagement.Console
{
    public static class PersonExtensions
    {
        public static async Task<string> Display(this Person person, IFeatureFlagManagement featureManager) => await featureManager.IsFeatureEnabledAsync(person) switch
        {
            true => string.Concat("Verbose Logging enabled: ", person.Name, " - ", person.Address),
            _ => string.Concat("Verbose Logging disabled: ", person.Name)
        };

        public static async Task<string> CustomDisplay(this Person person, IFeatureFlagManagement featureManager) => await featureManager.IsFeatureEnabledAsync("AddressLogging", person) switch
        {
            true => string.Concat("Address Logging enabled: ", person.Name, " - ", person.Address),
            _ => string.Concat("Address Logging disabled: ", person.Name)
        };
    }
}
