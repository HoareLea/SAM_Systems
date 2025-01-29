using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Schedule Function Type")]
    public enum ScheduleFunctionType
    {
        [Description("None")] None,
        [Description("Nearest Zone Load")] NearestZoneLoad,
        [Description("All Zones Load")] AllZonesLoad,
    }
}

