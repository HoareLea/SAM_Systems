using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Cooling Tower Data Type")]
    public enum CoolingTowerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Air Wetbulb")] AirWetbulb = 4,
        [Description("Cooling Output")] CoolingOutput = 5,
        [Description("Total Consumption")] TotalConsumption = 6,
        [Description("Fan Load")] FanLoad = 7,
        [Description("Ancillary Load")] AncillaryLoad = 8,
        [Description("Make Up Water")] MakeUpWater = 9,
        [Description("Air Flow Rate")] AirFlowRate = 10,
    }
}
