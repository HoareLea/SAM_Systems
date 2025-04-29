using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(Core.Systems.ISystemController)), Description("System Controller Parameter")]
    public enum SystemControllerParameter
    {
        [ParameterProperties("Group Index", "Group Index"), IntegerParameterValue()] GroupIndex,
    }
}
