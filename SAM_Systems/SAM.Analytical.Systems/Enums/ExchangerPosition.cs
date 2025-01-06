using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Exchanger Position")]
    public enum ExchangerPosition
    {
        [Description("None")] None,
        [Description("Left")] Left,
        [Description("Right")] Right,
        [Description("LeftOverRight")] LeftOverRight,
        [Description("RightOverLeft")] RightOverLeft,
    }
}