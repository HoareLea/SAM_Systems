using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemCoolingCoil)), Description("System Cooling Coil Parameter")]
    public enum SystemCoolingCoilParameter
    {
        [ParameterProperties("Cooling Collection", "Cooling Collection"), SAMObjectParameterValue(typeof(CollectionLink))] CoolingCollection,
    }
}
