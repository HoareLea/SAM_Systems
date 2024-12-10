using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Boiler Sequence")]
    public enum BoilerSequence
    {
        [Description("Parallel")] Parallel,
        [Description("Serial")] Serial,
        [Description("Staging")] Staging,
    }
}