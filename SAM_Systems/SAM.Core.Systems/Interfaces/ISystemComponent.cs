using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public interface ISystemComponent : ISystemJSAMObject
    {
        SystemConnectorManager SystemConnectorManager { get; }

        List<SystemConnector> GetSystemConnectors(SystemPlantRoom systemPlantRoom, ConnectorStatus connectorStatus);

        List<ISystemConnection> GetSystemConnections(SystemPlantRoom systemPlantRoom, SystemConnector systemConnector);
    }
}
