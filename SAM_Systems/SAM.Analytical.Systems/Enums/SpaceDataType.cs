using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Space Data Type")]
    public enum SpaceDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Humidity Ratio")] HumidityRatio = 4,
        [Description("Relative Humidity")] RelativeHumidity = 5,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 6,
        [Description("Enthalpy")] Enthalpy = 7,
        [Description("Pollutant")] Pollutant = 8,
        [Description("Zone Temperature")] ZoneTemperature = 9,
        [Description("Equipment Gain")] EquipmentGain = 10,
        [Description("Lighting Gain")] LightingGain = 11,
    }
}
