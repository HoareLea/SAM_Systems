using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Solar Panel Data Type")]
    public enum SolarPanelDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Generated")] Generated = 4,
    }
}
