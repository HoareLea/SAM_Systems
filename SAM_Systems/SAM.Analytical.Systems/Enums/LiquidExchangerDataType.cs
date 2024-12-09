using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Liquid Exchanger Data Type")]
    public enum LiquidExchangerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
    }
}
