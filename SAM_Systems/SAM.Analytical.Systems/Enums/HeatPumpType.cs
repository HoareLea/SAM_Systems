using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Heat Pump Type")]
    public enum HeatPumpType
    {
        [Description("Single Split")] SingleSplit,
        [Description("Multi Split")] MultiSplit,
        [Description("VRF")] VRF,
        [Description("VRFBC")] VRFBC,
        [Description("HVRFBC")] HVRFBC,
    }
}