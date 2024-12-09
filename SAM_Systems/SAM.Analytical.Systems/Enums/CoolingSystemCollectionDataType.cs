using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Cooling System Collection Data Type")]
    public enum CoolingSystemCollectionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Cooling Demand")] CoolingDemand = 4,
    }
}

