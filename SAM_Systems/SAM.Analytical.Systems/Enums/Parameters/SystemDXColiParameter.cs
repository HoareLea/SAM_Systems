using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemDXCoil)), Description("System DX Coil Parameter")]
    public enum SystemDXCoilParameter
    {
        [ParameterProperties("Refrigerant Collection", "Refrigerant Collection"), SAMObjectParameterValue(typeof(CollectionLink))] RefrigerantCollection,
    }
}
