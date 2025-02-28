using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemDXCoilUnit)), Description("System DXCoilUnit Parameter")]
    public enum SystemDXCoilUnitParameter
    {
        [ParameterProperties("Refrigerant Collection", "Refrigerant Collection"), SAMObjectParameterValue(typeof(CollectionLink))] RefrigerantCollection,
        [ParameterProperties("Electrical Collection", "Electrical Collection"), SAMObjectParameterValue(typeof(CollectionLink))] ElectricalCollection,
    }
}
