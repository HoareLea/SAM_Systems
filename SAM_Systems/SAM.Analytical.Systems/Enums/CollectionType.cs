using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Collection Type")]
    public enum CollectionType
    {
        [Description("Undefined")] Undefined,
        [Description("Cooling")] Cooling,
        [Description("Domestic Hot Water")] DomesticHotWater,
        [Description("Electrical")] Electrical,
        [Description("Fuel")] Fuel,
        [Description("Heating")] Heating,
        [Description("Refrigerant")] Refrigerant,
    }
}
