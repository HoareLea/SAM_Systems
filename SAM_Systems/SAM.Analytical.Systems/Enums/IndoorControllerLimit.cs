using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Indoor Controller Limit")]
    public enum IndoorControllerLimit
    {
        [Description("Lower Limit")] Lower = 1,
        [Description("Upper Limit")] Upper = 2,
        [Description("Lower and Upper Limit")] LowerAndUpper = 3
    }
}
