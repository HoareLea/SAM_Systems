using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Air Source Chiller Data Type")]
    public enum AirSourceChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Demand")] Demand = 4,
        [Description("Consumption")] Consumption = 5,
        [Description("Compressor")] Compressor = 6,
        [Description("Fan Load")] FanLoad = 7,
    }
}