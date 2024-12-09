using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Fuel System Collection Data Type")]
    public enum FuelSystemCollectionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Fuel Demand")] FuelDemand = 4,
    }
}

