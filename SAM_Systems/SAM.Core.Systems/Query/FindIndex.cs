using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        
        public static int FindIndex(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent, SystemType systemType, ConnectorStatus connectorStatus = Systems.ConnectorStatus.Undefined, Direction? direction = null)
        {
            if (systemPlantRoom == null || systemComponent == null)
            {
                return -1;
            }

            List<int> indexes = direction == null  || !direction.HasValue ? systemComponent.SystemConnectorManager?.GetIndexes(systemType) : systemComponent.SystemConnectorManager?.GetIndexes(systemType, direction.Value);
            if (indexes == null || indexes.Count == 0)
            {
                return -1;
            }

            if(connectorStatus == Systems.ConnectorStatus.Undefined)
            {
                return indexes[0];
            }

            foreach (int index in indexes)
            {
                ISystemConnection systemConnection = SystemConnection(systemPlantRoom, systemComponent, index);

                if((systemConnection == null && connectorStatus == Systems.ConnectorStatus.Unconnected) || (systemConnection != null && connectorStatus == Systems.ConnectorStatus.Connected))
                {
                    return index;
                }
            }

            return -1;
        }
    }
}