using SAM.Core.Attributes;
using SAM.Core;
using System.ComponentModel;

namespace SAM.Core.Systems
{
    [AssociatedTypes(typeof(SystemObject)), Description("System Object Parameters")]
    public enum SystemObjectParameter
    {
        [ParameterProperties("Energy Source Name", "Energy Source Name"), ParameterValue(ParameterType.String)] EnergySourceName,
        [ParameterProperties("Electrical Energy Source Name", "Electrical Energy Source Name"), ParameterValue(ParameterType.String)] ElectricalEnergySourceName,
        [ParameterProperties("Ancillary Source Name", "Ancillary Source Name"), ParameterValue(ParameterType.String)] AncillarySourceName,
        [ParameterProperties("Fan Source Name", "Fan Source Name"), ParameterValue(ParameterType.String)] FanSourceName,
    }
}
