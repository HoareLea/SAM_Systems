using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Exchanger Data Type")]
    public enum ExchangerDataType
    {
        [Description("Outside Flow Rate")] OutsideFlowRate = 1,
        [Description("Extract Flow Rate")] ExtractFlowRate = 2,
        [Description("Outside Pressure")] OutsidePressure = 3,
        [Description("Extract Pressure")] ExtractPressure = 4,
        [Description("Outside Temperature")] OutsideTemperature = 5,
        [Description("Extract Temperature")] ExtractTemperature = 6,
        [Description("Outside Humidity Ratio")] OutsideHumidityRatio = 7,
        [Description("Extract Humidity Ratio")] ExtractHumidityRatio = 8,
        [Description("Outside Relative Humidity")] OutsideRelativeHumidity = 9,
        [Description("Extract Relative Humidity")] ExtractRelativeHumidity = 10,
        [Description("Outside Enthalpy")] OutsideEnthalpy = 11,
        [Description("Extract Enthalpy")] ExtractEnthalpy = 12,
        [Description("Outside Pollutant")] OutsidePollutant = 13,
        [Description("Extract Pollutant")] ExtractPollutant = 14,
        [Description("Load")] Load = 15,
    }
}
