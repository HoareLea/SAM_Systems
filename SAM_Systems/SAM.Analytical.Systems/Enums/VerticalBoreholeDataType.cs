using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Vertical Borehole Data Type")]
    public enum VerticalBoreholeDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Load")] Load = 4,
        [Description("Borehole Temperature")] BoreholeTemperature = 5,
    }
}
