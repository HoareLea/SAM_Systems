using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Boiler Data Type")]
    public enum BoilerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Demand")] Demand = 4,
        [Description("Total Consumption")] TotalConsumption = 5,
        [Description("Primary Consumption")] PrimaryConsumption = 6,
        [Description("Ancillary Load")] AncillaryLoad = 7,
    }
}