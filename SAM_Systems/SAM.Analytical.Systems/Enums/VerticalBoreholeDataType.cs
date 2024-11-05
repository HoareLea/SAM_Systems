using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Vertical Borehole Data Type")]
    public enum VerticalBoreholeDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Load")] Load = 3,
        [Description("Borehole Temperature")] BoreholeTemperature = 4,
    }
}
