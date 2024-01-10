using System.ComponentModel;

namespace SAM.Core.Systems
{
    [Description("ConnectorStatus")]
    public enum ConnectorStatus
    {
        [Description("Undefined")] Undefined,
        [Description("Connected")] Connected,
        [Description("Unconnected")] Unconnected,
    }
}
