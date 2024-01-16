using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Space Data Type")]
    public enum SpaceDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Supply Air Temperature")] SupplyAirTemperature = 3,
        [Description("Supply Air Humidity Ratio")] SupplyAirHumidityRatio = 4,
        [Description("Supply Air Relative Humidity")] SupplyAirRelativeHumidity = 5,
        [Description("Supply Air Wet Bulb Temperature")] SupplyAirWetBulbTemperature = 6,
        [Description("Supply Air Enthalpy")] SupplyAirEnthalpy = 7,
        [Description("Supply Air Pollutant")] SupplyAirPollutant = 8,
        [Description("Zone Temperature")] ZoneTemperature = 9,
        [Description("Equipment Gain")] EquipmentGain = 10,
        [Description("Lighting Gain")] LightingGain = 11,
    }
}
