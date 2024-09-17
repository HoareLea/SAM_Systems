using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Normal Controller Limit")]
    public enum NormalControllerLimit
    {
        [Description("Lower Limit")] Lower = 1,
        [Description("Upper Limit")] Upper = 2,
        [Description("Lower and Upper Limit")] LowerAndUpper = 3
    }
}
