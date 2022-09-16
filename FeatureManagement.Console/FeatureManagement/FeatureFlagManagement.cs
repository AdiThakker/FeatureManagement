using FeatureManagement.Console.FeatureManagement.Interfaces;

namespace FeatureManagement.Console.FeatureManagement
{
    public class FeatureFlagManagement : IFeatureFlagManagement
    {
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
    }
}
