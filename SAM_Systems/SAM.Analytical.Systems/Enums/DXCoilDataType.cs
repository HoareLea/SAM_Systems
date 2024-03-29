﻿using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("DX Coil Data Type")]
    public enum DXCoilDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Humidity Ratio")] HumidityRatio = 4,
        [Description("Relative Humidity")] RelativeHumidity = 5,
        [Description("Wet Bulb Temperature")] WetBulbTemperature = 6,
        [Description("Enthalpy")] Enthalpy = 7,
        [Description("Pollutant")] Pollutant = 8,
        [Description("Heating Sensible Load")] HeatingSensibleLoad = 9,
        [Description("Cooling Sensible Load")] CoolingSensibleLoad = 10,
        [Description("Cooling Latent Load")] CoolingLatentLoad = 11,
        [Description("Condensation")] Condensation = 12,
    }
}
