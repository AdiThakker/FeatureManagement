using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureManagement.Console
{
    public class Outer
    {

        public Outer(ILogger<Outer> logger, Inner inner) => (this.Logger, this.Inner) = (logger, inner);

        public ILogger<Outer> Logger { get; }

        public Inner Inner { get; }

        public void Log(string message)
        {
            using (this.Logger.BeginScope("Scope:Outer"))
            {
                this.Logger.LogInformation(message);
                this.Inner.Log(message);
            }
        }

        public void Log(Action action)
        {
            using (this.Logger.BeginScope("Scope:Outer"))
                action();
        }
    }
}
