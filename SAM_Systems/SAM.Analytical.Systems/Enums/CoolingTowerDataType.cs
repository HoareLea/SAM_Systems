using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Cooling Tower Data Type")]
    public enum CoolingTowerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Air Wetbulb")] AirWetbulb = 3,
        [Description("Cooling Output")] CoolingOutput = 4,
        [Description("Total Consumption")] TotalConsumption = 5,
        [Description("Fan Load")] FanLoad = 6,
        [Description("Ancillary Load")] AncillaryLoad = 7,
        [Description("Make Up Water")] MakeUpWater = 8,
        [Description("Air Flow Rate")] AirFlowRate = 9,
    }
}
