using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(IAirSystemComponent)), Description("Air System Component Parameter")]
    public enum AirSystemComponentParameter
    {
        [ParameterProperties("Electrical Collection", "Electrical Collection"), Core.Attributes.SAMObjectParameterValue(typeof(CollectionLink))] ElectricalCollection,
    }
}
