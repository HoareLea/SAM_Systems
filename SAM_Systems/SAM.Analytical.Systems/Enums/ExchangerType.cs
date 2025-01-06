using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Exchanger Type")]
    public enum ExchangerType
    {
        [Description("Simple")] Simple,
        [Description("CounterFlow")] CounterFlow,
        [Description("ParallelFlow")] ParallelFlow,
        [Description("CrossFlowUnmixed")] CrossFlowUnmixed,
        [Description("CrossFlowMixed")] CrossFlowMixed,
    }
}