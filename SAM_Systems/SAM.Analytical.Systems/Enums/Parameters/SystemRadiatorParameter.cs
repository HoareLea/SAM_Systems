using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemRadiator)), Description("System Radiator Parameter")]
    public enum SystemRadiatorParameter
    {
        [ParameterProperties("Heating Collection", "Heating Collection"), SAMObjectParameterValue(typeof(CollectionLink))] HeatingCollection,
    }
}
