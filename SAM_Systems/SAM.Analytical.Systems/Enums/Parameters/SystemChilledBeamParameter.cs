using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemChilledBeam)), Description("System ChilledBeam Parameter")]
    public enum SystemChilledBeamParameter
    {
        [ParameterProperties("Cooling Collection", "Cooling Collection"), SAMObjectParameterValue(typeof(CollectionLink))] CoolingCollection,
    }
}
