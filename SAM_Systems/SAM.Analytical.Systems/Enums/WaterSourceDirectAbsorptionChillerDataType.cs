using System.ComponentModel;
using System.Net.NetworkInformation;

namespace SAM.Analytical.Systems
{
    [Description("Water Source Direct Absorption Chiller Data Type")]
    public enum WaterSourceDirectAbsorptionChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Demand")] Demand = 3,
        [Description("Consumption")] Consumption = 4,
        [Description("Compressor")] Compressor = 5,
        [Description("Fan Load")] FanLoad = 6,
    }
}