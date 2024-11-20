using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Electrical System Collection Type")]
    public enum ElectricalSystemCollectionType
    {
        [Description("None")] None,
        [Description("Fans")] Fans,
        [Description("Lighting")] Lighting,
        [Description("Equipment")] Equipment,
        [Description("Heating")] Heating,
    }
}
