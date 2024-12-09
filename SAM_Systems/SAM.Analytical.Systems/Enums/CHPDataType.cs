using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("CHP Data Type")]
    public enum CHPDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Heating Demand")] HeatingDemand = 4,
        [Description("Heating Consumption")] HeatingConsumption = 5,
        [Description("Electricity Generated")] ElectricityGenerated = 6,
    }
}
