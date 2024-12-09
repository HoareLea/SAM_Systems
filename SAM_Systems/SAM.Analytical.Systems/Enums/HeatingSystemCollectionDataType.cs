using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Heating System Collection Data Type")]
    public enum HeatingSystemCollectionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Heating Demand")] HeatingDemand = 4,
    }
}

