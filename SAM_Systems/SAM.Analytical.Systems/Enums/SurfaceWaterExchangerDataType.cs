using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Surface Water Exchanger Data Type")]
    public enum SurfaceWaterExchangerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Load")] Load = 4,
        [Description("Pond Temperature")] PondTemperature = 5,
    }
}
