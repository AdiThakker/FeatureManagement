namespace FeatureManagement.Console.FeatureManagement.Interfaces
{
    public interface IFeatureFlagManagement
    {
        Task<bool> IsFeatureEnabledAsync(string name);

        Task<bool> IsFeatureEnabledAsync<TType>(TType instance) where TType: class;

        Task<bool> IsFeatureEnabledAsync<TContext>(string name, TContext context);

        Task<bool> IsFeatureEnabledAsync<TType, TContext>(TType instance, TContext context) where TType : class;

        Task<TResult> ExecuteIfFeatureEnabledAsync<TResult>(Func<TResult> executeFunc);

        Task<TResult> ExecuteIfFeatureEnabledAsync<TResult, TContext>(Func<TResult> executeFunc, TContext context);
    }
}
