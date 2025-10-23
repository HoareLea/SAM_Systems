using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Four Pipe Heat Pump Data Type")]
    public enum FourPipeHeatPumpDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Heating Demand")] HeatingDemand = 4,
        [Description("Cooling Demand")] CoolingDemand = 5,
        [Description("Consumption")] Consumption = 6,
        [Description("Compressor")] Compressor = 7,
        [Description("Ancillary Load")] AncillaryLoad = 8,
    }
}