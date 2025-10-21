using System.ComponentModel;

namespace SAM.Core.Systems
{
    [Description("LabelDirection")]
    public enum LabelDirection
    {
        [Description("Undefined")] Undefined,
        [Description("Left Right")] LeftRight,
        [Description("Right Left")] RightLeft,
        [Description("Top Bottom")] TopBottom,
        [Description("Bottom Top")] BottomTop,
    }
}
