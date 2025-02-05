using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemLoadComponent)), Description("System Load Component Parameter")]
    public enum SystemLoadComponentParameter
    {
        [ParameterProperties("Collection", "Collection"), SAMObjectParameterValue(typeof(CollectionLink))] Collection,
    }
}
