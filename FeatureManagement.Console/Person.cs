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
        public string Name { get; set; }

        public string Address { get; set; }

        public Person()
        {
            Name = "John Doe";
            Address = "123 Main St";

        }
    }
}
