using System.ComponentModel;
using System.Net.NetworkInformation;

namespace SAM.Analytical.Systems
{
    [Description("Water Source Direct Absorption Chiller Data Type")]
    public enum WaterSourceDirectAbsorptionChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Demand")] Demand = 4,
        [Description("Total Consumption")] TotalConsumption = 5,
        [Description("Primary Consumption")] PrimaryConsumption = 6,
        [Description("Ancilliary Load")] AncilliaryLoad = 7,
    }
}