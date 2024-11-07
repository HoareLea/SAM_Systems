using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Wind Turbine Data Type")]
    public enum WindTurbineDataType
    {
        [Description("Wind Speed")] WindSpeed = 1,
        [Description("Generated")] Generated = 2
    }
}
