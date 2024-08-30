using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Indoor Controller Data Type")]
    public enum IndoorControllerDataType
    {
        [Description("Dry Bulb Temperature")] DryBulbTemperature = 1,
        [Description("Humidity Ratio")] HumidityRatio = 2,
        [Description("Relative Humidity")] RelativeHumidity = 3,
        [Description("Enthalpy")] Enthalpy = 4,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 5,
        [Description("Flow")] Flow = 6,
        [Description("Pollutant")] Pollutant = 7,
        [Description("Pressure")] Pressure = 8,
        [Description("Thermostat Temperature")] ThermostatTemperature = 9,
        [Description("Humidistat Relative Humidity")] HumidistatRelativeHumidity = 10,
        [Description("Minimal Fresh Air")] MinimalFreshAir = 11,
    }
}
