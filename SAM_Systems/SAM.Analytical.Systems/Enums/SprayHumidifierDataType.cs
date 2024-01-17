using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Spray Humidifier Data Type")]
    public enum SprayHumidifierDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Humidity Ratio")] HumidityRatio = 4,
        [Description("Relative Humidity")] RelativeHumidity = 5,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 6,
        [Description("Enthalpy")] Enthalpy = 7,
        [Description("Pollutant")] Pollutant = 8,
        [Description("Water Use")] WaterUse = 9,
        [Description("Cooling")] Cooling = 10,
        [Description("Electrical Load")] ElectricalLoad = 11,
    }
}
