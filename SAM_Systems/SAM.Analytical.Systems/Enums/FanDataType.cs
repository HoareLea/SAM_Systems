using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Fan Data Type")]
    public enum FanDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("HumidityRatio")] HumidityRatio = 4,
        [Description("RelativeHumidity")] RelativeHumidity = 5,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 6,
        [Description("Enthalpy")] Enthalpy = 7,
        [Description("Pollutant")] Pollutant = 8,
        [Description("Load")] Load = 9,
    }
}

