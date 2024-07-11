using System.ComponentModel;
using SAM.Core.Attributes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemEnergyCentre)), Description("SystemEnergyCentre Parameter")]
    public enum SystemEnergyCentreParameter
    {
        [ParameterProperties("Annual Total Consumption", "Annual Total Consumption [kWh]"), ParameterValue(Core.ParameterType.Double)] AnnualTotalConsumption,
        [ParameterProperties("Annual CO2 Emission", "Annual CO2 Emission [kg]"), ParameterValue(Core.ParameterType.Double)] AnnualCO2Emission,
        [ParameterProperties("Annual Cost", "Annual Cost"), ParameterValue(Core.ParameterType.Double)] AnnualCost,
        [ParameterProperties("Annual Unmet Hours", "Annual Unmet Hours [h]"), ParameterValue(Core.ParameterType.Double)] AnnualUnmetHours,
    }
}
