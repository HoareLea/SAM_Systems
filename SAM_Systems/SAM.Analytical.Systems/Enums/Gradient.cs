using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Gradient")]
    public enum Gradient
    {
        [Description("Undefined")] Undefined,
        [Description("Positive")] Positive,
        [Description("Negative")] Negative,
    }
}