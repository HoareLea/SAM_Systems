using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Dry Cooler Data Type")]
    public enum DryCoolerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Air Flow Rate")] AirFlowRate = 4,
        [Description("Heat Rejected")] HeatRejected = 5,
        [Description("Total Consumption")] TotalConsumption = 6,
        [Description("Fan Load")] FanLoad = 7,
        [Description("Ancillary Load")] AncillaryLoad = 8,
    }
}
