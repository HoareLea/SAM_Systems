using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("CHP Data Type")]
    public enum CHPDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Heating Demand")] HeatingDemand = 3,
        [Description("Heating Consumption")] HeatingConsumption = 4,
        [Description("Electricity Generated")] ElectricityGenerated = 5,
    }
}
