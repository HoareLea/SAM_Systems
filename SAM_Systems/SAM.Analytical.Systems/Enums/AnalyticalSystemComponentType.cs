using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Analytical System Component Type")]
    public enum AnalyticalSystemComponentType
    {
        [Description("Undefined")] Undefined,
        [Description("System Heating Coil")] SystemHeatingCoil,
        [Description("System Cooling Coil")] SystemCoolingCoil,
        [Description("System Fan")] SystemFan,
    }
}
