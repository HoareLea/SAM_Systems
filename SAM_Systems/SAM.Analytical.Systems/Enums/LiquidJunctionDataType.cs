using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Liquid Juction Data Type")]
    public enum LiquidJunctionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
    }
}