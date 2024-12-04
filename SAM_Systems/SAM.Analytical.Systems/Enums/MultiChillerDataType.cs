using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Multi Chiller Data Type")]
    public enum MultiChillerDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,

        [Description("Demand 1")] Demand1 = 4,
        [Description("Consumption 1")] Consumption1 = 5,
        [Description("Compressor 1")] Compressor1 = 6,
        [Description("Fan Load 1")] FanLoad1 = 7,

        [Description("Demand 2")] Demand2 = 8,
        [Description("Consumption 2")] Consumption2 = 9,
        [Description("Compressor 2")] Compressor2 = 10,
        [Description("Fan Load 2")] FanLoad2 = 11,

        [Description("Demand 3")] Demand3 = 12,
        [Description("Consumption 3")] Consumption3 = 13,
        [Description("Compressor 3")] Compressor3 = 14,
        [Description("Fan Load 3")] FanLoad3 = 15,

        [Description("Demand 4")] Demand4 = 16,
        [Description("Consumption 4")] Consumption4 = 17,
        [Description("Compressor 4")] Compressor4 = 18,
        [Description("Fan Load 4")] FanLoad4 = 19,
    }
}
