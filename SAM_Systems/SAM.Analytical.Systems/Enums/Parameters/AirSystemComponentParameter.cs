using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(IAirSystemComponent)), Description("Air System Component Parameter")]
    public enum AirSystemComponentParameter
    {
        [ParameterProperties("Electrical Collection", "Electrical Collection"), SAMObjectParameterValue(typeof(CollectionLink))] ElectricalCollection,
        [ParameterProperties("Group Index", "Group Index"), IntegerParameterValue()] GroupIndex,
    }
}
