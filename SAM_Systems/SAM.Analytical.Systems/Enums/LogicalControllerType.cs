using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Logical Controller Type")]
    public enum LogicalControllerType
    {
        [Description("Maximal")] Max = 1,
        [Description("Minimal")] Min = 2,
        [Description("Not")] Not = 3,
        [Description("If")] If = 4,
        [Description("Signal")] Sig = 5,
    }
}
