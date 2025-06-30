using System.ComponentModel;

namespace SAM.Analytical.Grasshopper.Systems
{
    [Description("Line Category")]
    public enum LineCategory
    {
        [Description("Undefined")] Undefined,
        [Description("Control")] Control,
        [Description("Sensor")] Sensor,
    }
}
