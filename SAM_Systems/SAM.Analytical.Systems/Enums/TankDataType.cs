using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Tank Data Type")]
    public enum TankDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Pressure")] Pressure = 2,
        [Description("Temperature")] Temperature = 3,
        [Description("Tank Temperature")] TankTemperature = 4,
        [Description("Storage Loss")] StorageLoss = 5,
    }
}

