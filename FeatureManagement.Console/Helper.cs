using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console
{
    public class Helper
    {

        public Helper(ILogger<Helper> logger) => this.Logger = logger;

        public ILogger<Helper> Logger { get; }

        public void Log(string message)
        {
            using (this.Logger.BeginScope("Scope:Helper"))
                this.Logger.LogInformation(message);
        }
    }
}
