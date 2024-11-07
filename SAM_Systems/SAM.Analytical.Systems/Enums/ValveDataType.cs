using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Valve Data Type")]
    public enum ValveDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
    }
}
