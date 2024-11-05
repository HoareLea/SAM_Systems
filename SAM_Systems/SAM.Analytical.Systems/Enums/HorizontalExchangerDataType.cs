using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Horizontal Exchanger Data Type")]
    public enum HorizontalExchangerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Load")] Load = 3,
        [Description("Trench Bottom Temperature")] TrenchBottomTemperature = 4,
    }
}
