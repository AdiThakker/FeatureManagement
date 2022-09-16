namespace FeatureManagement.Console.FeatureManagement.Interfaces
{
    public interface IFeatureFlagManagement
    {
        Task<bool> IsFeatureEnabledAsync(string name);

        Task<bool> IsFeatureEnabledAsync<TContext>(string name, TContext context);

        Task<TResult> ExecuteIfFeatureEnabledAsync<TResult>(Func<TResult> executeFunc);
    }
}
