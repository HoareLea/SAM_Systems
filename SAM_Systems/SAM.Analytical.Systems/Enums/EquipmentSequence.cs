using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Equipment Sequence")]
    public enum EquipmentSequence
    {
        [Description("Parallel")] Parallel,
        [Description("Serial")] Serial,
        [Description("Staging")] Staging,
    }
}