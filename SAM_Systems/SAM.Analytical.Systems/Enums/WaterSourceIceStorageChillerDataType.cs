using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Water Source Ice Source Chiller Data Type")]
    public enum WaterSourceIceStorageChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Demand")] Demand = 4,
        [Description("Consumption")] Consumption = 5,
        [Description("Water Cooling")] WaterCooling = 6,
        [Description("Ice Reserve")] IceReserve = 7,
        [Description("Compressor")] Compressor = 8,
        [Description("Ancilliary Load")] AncilliaryLoad = 9,
    }
}
