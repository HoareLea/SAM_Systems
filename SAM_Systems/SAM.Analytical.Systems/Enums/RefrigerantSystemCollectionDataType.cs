using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Refrigerant System Collection Data Type")]
    public enum RefrigerantSystemCollectionDataType
    {
        [Description("Refrigerant Demand")] RefrigerantDemand = 1,
        [Description("Heating")] Heating = 2,
        [Description("Cooling")] Cooling = 3,
    }
}

