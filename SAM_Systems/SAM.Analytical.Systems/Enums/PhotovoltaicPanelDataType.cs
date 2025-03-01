﻿using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Photovoltaic Panel Data Type")]
    public enum PhotovoltaicPanelDataType
    {
        [Description("Generated")] Generated = 1,
        [Description("Panel Temperature")] PanelTemperature = 2,
        [Description("Incident Solar Radiation")] IncidentSolarRadiation = 3,
    }
}
