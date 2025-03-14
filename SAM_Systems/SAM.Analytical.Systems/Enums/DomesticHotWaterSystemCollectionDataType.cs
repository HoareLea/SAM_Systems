﻿using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Domestic Hot Water System Collection Data Type")]
    public enum DomesticHotWaterSystemCollectionDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("DHW Demand")] DHWDemand = 4,
    }
}