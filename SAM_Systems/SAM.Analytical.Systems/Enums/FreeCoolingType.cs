using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Free Cooling Type")]
    public enum FreeCoolingType
    {
        [Description("None")] None,
        [Description("OnOff")] OnOff,
        [Description("Variable")] Variable,
    }
}