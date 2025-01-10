using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("External Wet Bulb Temperature Sizing Type")]
    public enum ExternalWetBulbTemperatureSizingType
    {
        [Description("Max Operating")] MaxOperating,
        [Description("Peak External")] PeakExternal,
        [Description("Value")] Value,
    }
}