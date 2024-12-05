using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Electrical System Collection Data Type")]
    public enum ElectricalSystemCollectionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Electrical Demand")] ElectricalDemand = 4,
    }
}

