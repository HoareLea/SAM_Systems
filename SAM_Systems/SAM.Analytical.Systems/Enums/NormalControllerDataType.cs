using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Normal Controller Data Type")]
    public enum NormalControllerDataType
    {
        [Description("DryBulbTemperature")] DryBulbTemperature = 1,
        [Description("Humidity Ratio")] HumidityRatio,
        [Description("Relative Humidity")] RelativeHumidity,
        [Description("Enthalpy")] Enthalpy,
        [Description("Flow")] Flow,
        [Description("Pollutant")] Pollutant,
        [Description("Pressure")] Pressure,
        [Description("Thermostat Temperature")] ThermostatTemperature,
        [Description("Humidistat Relative Humidity")] HumidistatRelativeHumidity,
        [Description("Load")] Load,
        [Description("Wet Bulb Temperature")] WetBulbTemperature,
        [Description("Min Flow")] MinFlow,
        [Description("Part Load")] PartLoad,
    }
}
