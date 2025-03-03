using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Sized Flow Method")]
    public enum SizedFlowMethod
    {
        [Description("Per Meter Squared")] PerMeterSquared,
        [Description("Per Meter Cubed")] PerMeterCubed,
        [Description("Flow Air Changes per Hour")] FlowACH,
        [Description("Peak Person")] PeakPerson,
        [Description("Peak Internal Condition")] PeakInternalCondition,
        [Description("Temperature Difference")] TemperatureDifference,
        [Description("Peak Person And Area")] PeakPersonAndArea,
        [Description("Hourly Person")] HourlyPerson,
        [Description("Hourly Internal Condition")] HourlyInternalCondition,
        [Description("Hourly Person And Area")] HourlyPersonAndArea,
        [Description("Peak Ventilation")] PeakVentilation,
        [Description("Hourly Ventilation")] HourlyVentilation,
    }
}
