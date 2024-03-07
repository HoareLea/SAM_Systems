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
        [Description("System Boiler")] SystemBoiler,
        [Description("System Air Junction")] SystemAirJunction,
        [Description("System Chilled Beam")] SystemChilledBeam,
        [Description("System Damper")] SystemDamper,
        [Description("System Desiccant Wheel")] SystemDesiccantWheel,
        [Description("System Direct Evaporative Cooler")] SystemDirectEvaporativeCooler,
        [Description("System DX Coil Unit")] SystemDXCoilUnit,
        [Description("System Economiser")] SystemEconomiser,
        [Description("System Humidifier")] SystemHumidifier,
        [Description("System Mixing Box")] SystemMixingBox,
        [Description("System Spray Humidifier")] SystemSprayHumidifier,
        [Description("System Steam Humidifier")] SystemSteamHumidifier,
    }
}
