using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Electrical Group Type")]
    public enum ElectricalGroupType
    {
        [Description("Undefined")] Undefined,
        [Description("Fans")] Fans,
        [Description("Lighting")] Lighting,
        [Description("Equipment")] Equipment,
        [Description("Heating")] Heating,
        [Description("None")] None,
    }
}

