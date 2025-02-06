using System.ComponentModel;
using SAM.Core.Attributes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(ISystemConnection)), Description("System Connection Parameter")]
    public enum SystemConnectionParameter
    {
        [ParameterProperties("Fluid Type Name", "Fluid Type Name"), ParameterValue(Core.ParameterType.String)] FluidTypeName,
    }
}
