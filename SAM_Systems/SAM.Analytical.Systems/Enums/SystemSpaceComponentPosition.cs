using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("System Space Component Position")]
    public enum SystemSpaceComponentPosition
    {
        [Description("In Zone")] InZone,
        [Description("Terminal Unit")] TerminalUnit,
        [Description("Parallel Terminal Unit")] ParallelTerminalUnit,
    }
}