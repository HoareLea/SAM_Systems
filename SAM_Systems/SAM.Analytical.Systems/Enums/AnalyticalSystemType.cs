using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Analytical System Type")]
    public enum AnalyticalSystemType
    {
        [Description("Undefined")] Undefined,
        [Description("Air System")] AirSystem,
        [Description("Control System")] ControlSystem,
        [Description("Cooling System")] CoolingSystem,
        [Description("Electrical System")] ElectricalSystem,
        [Description("Heating System")] HeatingSystem,
        [Description("Refrigerant System")] RefrigerantSystem,
        [Description("Liquid System")] LiquidSystem,
    }
}
