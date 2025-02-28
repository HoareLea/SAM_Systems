using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemFanCoilUnit)), Description("System FanCoilUnit Parameter")]
    public enum SystemFanCoilUnitParameter
    {
        [ParameterProperties("Heating Collection", "Heating Collection"), SAMObjectParameterValue(typeof(CollectionLink))] HeatingCollection,
        [ParameterProperties("Cooling Collection", "Cooling Collection"), SAMObjectParameterValue(typeof(CollectionLink))] CoolingCollection,
        [ParameterProperties("Electrical Collection", "Electrical Collection"), SAMObjectParameterValue(typeof(CollectionLink))] ElectricalCollection,
    }
}
