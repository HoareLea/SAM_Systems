using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Pipe Loss Component Data Type")]
    public enum PipeLossComponentDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Heat Loss from Pipe")] HeatLoss = 3,
    }
}