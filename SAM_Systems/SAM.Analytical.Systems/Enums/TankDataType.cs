using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Tank Data Type")]
    public enum TankDataType
    {
        [Description("Flow Rate")] FlowRate = 1,
        [Description("Temperature")] Temperature = 2,
        [Description("Tank Temperature")] TankTemperature = 3,
        [Description("Storage Loss")] StorageLoss = 4,
    }
}

