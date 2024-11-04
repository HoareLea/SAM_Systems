using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Pump Data Type")]
    public enum PumpDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Load")] Load = 3,
    }
}
