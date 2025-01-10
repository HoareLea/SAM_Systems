using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Temperature Sizing Type")]
    public enum TemperatureSizingType
    {
        [Description("Max Operating")] MaxOperating,
        [Description("Peak External")] PeakExternal,
        [Description("Value")] Value,
    }
}