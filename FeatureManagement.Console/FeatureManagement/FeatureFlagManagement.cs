using FeatureManagement.Console.FeatureManagement.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace FeatureManagement.Console.FeatureManagement
{
    public class FeatureFlagManagement : IFeatureFlagManagement
    {
        private readonly ILogger<FeatureFlagManagement> logger;

        private readonly IFeatureManager featureManager;

        public FeatureFlagManagement(ILogger<FeatureFlagManagement> logger, IFeatureManager featureManager) 
            => (this.logger, this.featureManager) = (logger, featureManager);
        

        public Task<TResult> ExecuteIfFeatureEnabledAsync<TResult>(Func<TResult> executeFunc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFeatureEnabledAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFeatureEnabledAsync<TContext>(string name, TContext context)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> IsFeatureEnabledAsync<TContext>(string feature, FeatureFlagDefaultState defaultState, TContext context)
        {
            return context switch
            {
                null => await featureManager.IsEnabledAsync(feature),
                _ => await featureManager.IsEnabledAsync(feature, context)
            };
                
        }
    }
}
