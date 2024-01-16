using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Air Juction Data Type")]
    public enum AirJunctionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("HumidityRatio")] HumidityRatio = 4,
        [Description("RelativeHumidity")] RelativeHumidity = 5,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 6,
        [Description("Enthalpy")] Enthalpy = 7,
        [Description("Pollutant")] Pollutant = 8,
    }
}
