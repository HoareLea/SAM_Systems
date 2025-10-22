using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Load Component Value Type")]
    public enum LoadComponentValueType
    {
        [Description("Undefined")] Undefined,
        [Description("Load")] Load,
        [Description("Flow rate")] FlowRate,
    }
}

