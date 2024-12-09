using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Valve Data Type")]
    public enum ValveDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
    }
}
