using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Normal Controller Data Type")]
    public enum LiquidNormalControllerDataType
    {
        [Description("Temperature")] Temperature = 1,
        [Description("Flow")] Flow = 2,
        [Description("Pressure")] Pressure = 3,
        [Description("Load")] Load = 4,
    }
}
