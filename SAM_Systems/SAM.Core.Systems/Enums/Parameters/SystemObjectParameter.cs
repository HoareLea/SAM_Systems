using SAM.Core.Attributes;
using System.ComponentModel;

namespace SAM.Core.Systems
{
    [AssociatedTypes(typeof(SystemObject)), Description("System Object Parameters")]
    public enum SystemObjectParameter
    {
        [ParameterProperties("Energy Source Name", "Energy Source Name - Fuel Source"), ParameterValue(ParameterType.String)] EnergySourceName,
        [ParameterProperties("Electrical Energy Source Name", "Electrical Energy Source Name- Electrical Fuel Source"), ParameterValue(ParameterType.String)] ElectricalEnergySourceName,
        [ParameterProperties("Ancillary Energy Source Name", "Ancillary Energy Source Name - Ancillary Fuel Source Name"), ParameterValue(ParameterType.String)] AncillaryEnergySourceName,
        [ParameterProperties("Fan Energy Source Name", "Fan Energy Source Name - Fan Fuel Source Name"), ParameterValue(ParameterType.String)] FanEnergySourceName,
    }
}
