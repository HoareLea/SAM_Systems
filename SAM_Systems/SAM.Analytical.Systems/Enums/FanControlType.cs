using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Fan Control Type")]
    public enum FanControlType
    {
        [Description("Fixed Speed")] FixedSpeed,
        [Description("Variable Speed")] VariableSpeed,
    }
}

