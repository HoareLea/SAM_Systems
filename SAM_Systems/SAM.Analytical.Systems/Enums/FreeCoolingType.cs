using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Flow Rate Type")]
    public enum FlowRateType
    {
        [Description("None")] None,
        [Description("Value")] Value,
        [Description("All Attached Zones Flow Rate")] AllAttachedZonesFlowRate,
        [Description("All Attached Zones Fresh Air")] AllAttachedZonesFreshAir,
        [Description("Nearest Zone Flow Rate")] NearestZoneFlowRate,
        [Description("Nearest Zone Fresh Air")] NearestZoneFreshAir,
        [Description("Sized")] Sized,
        [Description("All Attached Zones Sized")] AllAttachedZonesSized,
    }
}