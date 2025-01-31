using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemHeatingCoil)), Description("System Heating Coil Parameter")]
    public enum SystemHeatingColiParameter
    {
        [ParameterProperties("Heating Collection", "Heating Collection"), SAMObjectParameterValue(typeof(CollectionLink))] HeatingCollection,
    }
}
