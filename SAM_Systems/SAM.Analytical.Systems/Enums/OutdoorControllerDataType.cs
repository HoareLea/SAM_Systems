using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Outdoor Controller Data Type")]
    public enum OutdoorControllerDataType
    {
        [Description("Dry Bulb Temperature")] DryBulbTemperature = 1,
        [Description("Humidity Ratio")] HumidityRatio = 2,
        [Description("Relative Humidity")] RelativeHumidity = 3,
        [Description("Enthalpy")] Enthalpy = 4,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 5,
        [Description("Pollutant")] Pollutant = 6,
    }
}
