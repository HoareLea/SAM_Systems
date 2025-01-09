using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Sizing Type")]
    public enum SizingType
    {
        [Description("None")] None,
        [Description("Sized")] Sized,
        [Description("Value")] Value,
    }
}