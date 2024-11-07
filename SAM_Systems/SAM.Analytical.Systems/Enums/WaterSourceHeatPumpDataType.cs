using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Water Source HeatPump Data Type")]
    public enum WaterSourceHeatPumpDataType
    {
        [Description("Heating Demand")] HeatingDemand = 1,
        [Description("Cooling Demand")] CoolingDemand = 2,
        [Description("Consumption")] Consumption = 3,
        [Description("Compressor")] Compressor = 4,
        [Description("Fan")] Fan = 5,
        [Description("Ancillary Load")] AncillaryLoad = 6,
    }
}