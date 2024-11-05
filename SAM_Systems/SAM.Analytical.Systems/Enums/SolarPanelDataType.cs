using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Solar Panel Data Type")]
    public enum SolarPanelDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Generated")] Generated = 3,
    }
}
