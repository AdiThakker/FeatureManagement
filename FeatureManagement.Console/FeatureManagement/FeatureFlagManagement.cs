using FeatureManagement.Console.FeatureManagement.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using System.Reflection;

namespace FeatureManagement.Console.FeatureManagement
{
    public class FeatureFlagManagement : IFeatureFlagManagement
    {
        private readonly ILogger<FeatureFlagManagement> logger;

        private readonly IFeatureManager featureManager;

        public FeatureFlagManagement(ILogger<FeatureFlagManagement> logger, IFeatureManager featureManager)
            => (this.logger, this.featureManager) = (logger, featureManager);


        public async Task<TResult> ExecuteIfFeatureEnabledAsync<TResult>(Func<TResult> executeFunc)
        {
            FeatureDefinitionAttribute? flag = GetAttribute<Type>(executeFunc.GetType());
            if (await IsFeatureEnabledAsyncHelper<object>(flag!.FeatureName, flag.DefaultState, null))
                return executeFunc();
            else
                return default;
        }

        public async Task<TResult> ExecuteIfFeatureEnabledAsync<TResult, TContext>(Func<TResult> executeFunc, TContext context)
        {
            FeatureDefinitionAttribute? flag = GetAttribute<Type>(executeFunc.GetType());
            if (await IsFeatureEnabledAsyncHelper<object>(flag!.FeatureName, flag.DefaultState, context))
                return executeFunc();
            else
                return default;
        }

        public async Task<bool> IsFeatureEnabledAsync(string name) => await IsFeatureEnabledAsyncHelper<object>(name, FeatureFlagDefaultState.Unkown, null);

        public async Task<bool> IsFeatureEnabledAsync<TContext>(string name, TContext context) => await IsFeatureEnabledAsyncHelper<TContext>(name, FeatureFlagDefaultState.Unkown, context);

        public async Task<bool> IsFeatureEnabledAsync<TType>(TType instance) where TType : class
        {
            FeatureDefinitionAttribute? flag = GetAttribute<Type>(instance.GetType());
            return await IsFeatureEnabledAsyncHelper<object>(flag!.FeatureName, flag.DefaultState, null);
        }

        public async Task<bool> IsFeatureEnabledAsync<TType, TContext>(TType instance, TContext context) where TType : class
        {
            FeatureDefinitionAttribute? flag = GetAttribute<Type>(instance.GetType());
            return await IsFeatureEnabledAsyncHelper<object>(flag!.FeatureName, flag.DefaultState, context);
        }

        Task<TResult> IFeatureFlagManagement.ExecuteIfFeatureEnabledAsync<TResult>(Func<TResult> executeFunc)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> IsFeatureEnabledAsyncHelper<TContext>(string feature, FeatureFlagDefaultState defaultState, TContext? context)
        {
            return context switch
            {
                null => await featureManager.IsEnabledAsync(feature),
                _ => await featureManager.IsEnabledAsync(feature, context)
            };
        }

        private FeatureDefinitionAttribute? GetAttribute<TResult>(Type executingType) => executingType.GetCustomAttributes(true).OfType<FeatureDefinitionAttribute>().FirstOrDefault();
    }
}
