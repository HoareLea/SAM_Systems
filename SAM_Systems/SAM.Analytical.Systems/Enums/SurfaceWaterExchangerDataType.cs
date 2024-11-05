using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Surface Water Exchanger Data Type")]
    public enum SurfaceWaterExchangerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Load")] Load = 3,
        [Description("Pond Temperature")] PondTemperature = 4,
    }
}
