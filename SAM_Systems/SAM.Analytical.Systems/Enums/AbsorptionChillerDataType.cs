using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Absorption Chiller Data Type")]
    public enum AbsorptionChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Demand")] Demand = 4,
        [Description("Consumption")] Consumption = 5,
        [Description("Ancilliary Load")] AncilliaryLoad = 6,

        //[Description("Compressor")] Compressor = 6,
        //[Description("Fan Load")] FanLoad = 7,
    }
}
