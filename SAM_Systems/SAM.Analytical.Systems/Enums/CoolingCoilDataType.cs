using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Cooling Coil Data Type")]
    public enum CoolingCoilDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Humidity Ratio")] HumidityRatio = 4,
        [Description("Relative Humidity")] RelativeHumidity = 5,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 6,
        [Description("Enthalpy")] Enthalpy = 7,
        [Description("Pollutant")] Pollutant = 8,
        [Description("Sensible Load")] SensibleLoad = 9,
        [Description("Latent Load")] LatentLoad = 10,
        [Description("Condensation")] Condensation = 11,
    }
}
