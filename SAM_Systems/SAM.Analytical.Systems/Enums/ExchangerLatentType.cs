using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Exchanger Latent Type")]
    public enum ExchangerLatentType
    {
        [Description("Humidity Ratio")] HumidityRatio,
        [Description("Enthalpy")] Enthalpy,
    }
}

