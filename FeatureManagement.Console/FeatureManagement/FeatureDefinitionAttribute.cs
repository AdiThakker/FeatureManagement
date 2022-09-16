namespace FeatureManagement.Console.FeatureManagement
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class FeatureDefinitionAttribute : Attribute
    {
        public string FeatureName { get; }

        public FeatureFlagDefaultState DefaultState { get; }

        public FeatureDefinitionAttribute(string name, FeatureFlagDefaultState flagDefaultState = FeatureFlagDefaultState.Unkown)
            => (FeatureName, DefaultState) = (name, flagDefaultState);

    }

    public enum FeatureFlagDefaultState : int
    {
        Unkown = 0,
        Disabled = 1,
        Enabled = 2
    }

}