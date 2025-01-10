using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Max Air Flow Rate Sizing Type")]
    public enum MaxAirFlowRateSizingType
    {
        [Description("Value")] Value,
        [Description("Fan Load Ratio")] FanLoadRatio,
        [Description("Air Flow / Water Flow Ratio")] AirFlowWaterFlowRatio,
    }
}