using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Horizontal Exchanger Data Type")]
    public enum HorizontalExchangerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Load")] Load = 4,
        [Description("Trench Bottom Temperature")] TrenchBottomTemperature = 5,
    }
}
