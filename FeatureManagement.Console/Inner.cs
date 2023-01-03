using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console
{
    public class Inner
    {
        public Inner(ILogger<Inner> logger) => this.Logger = logger;

        public ILogger<Inner> Logger { get; }

        public void Log(string message)
        {
            using (this.Logger.BeginScope("Scope:Inner"))
            this.Logger.LogInformation(message);
        }
    }
}
