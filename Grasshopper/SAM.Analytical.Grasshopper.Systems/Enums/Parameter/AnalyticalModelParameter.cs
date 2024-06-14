using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Grasshopper.Systems
{
    [AssociatedTypes(typeof(AnalyticalModel)), Description("AnalyticalModel System Parameter")]
    public enum AnalyticalModelParameter
    {
        [ParameterProperties("SystemEnergyCentre", "SAM SystemEnergyCentre"), SAMObjectParameterValue(typeof(Core.Systems.SystemEnergyCentre))] SystemEnergyCentre,
    }
}
