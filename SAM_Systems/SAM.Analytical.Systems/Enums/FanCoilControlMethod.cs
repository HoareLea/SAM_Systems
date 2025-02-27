using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Fan Coil Control Method")]
    public enum FanCoilControlMethod
    {
        [Description("CAV")] CAV,
        [Description("VAV")] VAV,
        [Description("On/Off")] OnOff,
    }
}