using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Dry Cooler Data Type")]
    public enum DryCoolerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Air Flow Rate")] AirFlowRate = 2,
        [Description("Heat Rejected")] HeatRejected = 3,
        [Description("Total Consumption")] TotalConsumption = 3,
        [Description("Fan Load")] FanLoad = 3,
        [Description("Ancillary Load")] AncillaryLoad = 3,
    }
}
