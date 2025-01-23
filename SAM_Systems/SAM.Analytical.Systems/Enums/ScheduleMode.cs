using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Schedule Mode")]
    public enum ScheduleMode
    {
        [Description("Through")] Through,
        [Description("Recirc")] Recirc,
        [Description("NoMinimum")] NoMinimum,
    }
}
