using FeatureManagement.Console.FeatureManagement;
using FeatureManagement.Console.FeatureManagement.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console.Entity
{
    public class Person
    {
        public string Name { get; init; }

        
        public string Location { get; init; }

        public ILogger<Person> Logger { get; init; }
        public IFeatureFlagManagement IFeatureFlagManagement { get; }

        public Person(string name, string location, ILogger<Person> logger, IFeatureFlagManagement featureFlags)
        {
            Name = name;
            Location = location;
            Logger = logger;
            IFeatureFlagManagement = featureFlags;
        }

        public async void Display()
        {
            StringBuilder contents = new StringBuilder(); 
            contents.Append(Name);

            if (await IFeatureFlagManagement.IsFeatureEnabledAsync("VerboseLogging"))
                contents = contents.AppendLine(Location);

            this.Logger.LogInformation(contents.ToString());
        }
    }
}
