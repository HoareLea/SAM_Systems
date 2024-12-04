using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Pipe Loss Component Data Type")]
    public enum PipeLossComponentDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Heat Loss from Pipe")] HeatLoss = 4,
    }
}