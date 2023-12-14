using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Fan Coild Unit Data Type")]
    public enum FanCoilUnitDataType
    {
        [Description("Heating Load")] HeatingLoad = 1,
        [Description("Cooling Sensible Load")] CoolingSensibleLoad = 2,
        [Description("Cooling Latent Load")] CoolingLatentLoad = 3,
        [Description("Electrical Load")] ElectricalLoad = 4,
        [Description("Condensation")] Condensation = 5,
    }
}
