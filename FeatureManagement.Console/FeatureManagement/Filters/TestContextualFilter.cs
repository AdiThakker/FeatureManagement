using Microsoft.FeatureManagement;

namespace FeatureManagement.Console.FeatureManagement.Filters
{
    public class TestContextualFilter : IContextualFeatureFilter<MyFeatureManagement.Test>
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext featureFilterContext, MyFeatureManagement.Test appContext)
        {
            var number = appContext.Number;
            return Task.FromResult(number == 1 ? true : false);
        }
    }
}
