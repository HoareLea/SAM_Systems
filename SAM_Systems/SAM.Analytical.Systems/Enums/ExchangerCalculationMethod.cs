using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Exchanger Calculation Method")]
    public enum ExchangerCalculationMethod
    {
        [Description("Simple")] Simple,
        [Description("NTU")] NTU,
        [Description("Duty")] Duty,
    }
}