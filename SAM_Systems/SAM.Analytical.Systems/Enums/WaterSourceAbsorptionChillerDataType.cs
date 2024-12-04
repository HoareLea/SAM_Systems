using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Water Source Absorption Chiller Data Type")]
    public enum WaterSourceAbsorptionChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Demand")] Demand = 4,
        [Description("Consumption")] Consumption = 5,
        [Description("Ancillary Load")] AncillaryLoad = 6,
    }
}

