using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Design Water Flow Rate Sizing Type")]
    public enum DesignWaterFlowRateSizingType
    {
        [Description("As Pump Design Flow Rate")] AsPumpDesignFlowRate,
        [Description("Value")] Value,
    }
}