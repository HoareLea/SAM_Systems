using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Boiler Data Type")]
    public enum BoilerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Demand")] Demand = 3,
        [Description("Total Consumption")] TotalConsumption = 4,
        [Description("Primary Consumption")] PrimaryConsumption = 5,
        [Description("Ancillary Load")] AncillaryLoad = 6,
    }
}