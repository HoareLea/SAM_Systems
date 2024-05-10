using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        
        public static HashSet<int> FindIndexes(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent, SystemType systemType, ConnectorStatus connectorStatus = Systems.ConnectorStatus.Undefined, Direction? direction = null)
        {
            if (systemPlantRoom == null || systemComponent == null)
            {
                return null;
            }

            List<int> indexes = direction == null  || !direction.HasValue ? systemComponent.SystemConnectorManager?.GetIndexes(systemType) : systemComponent.SystemConnectorManager?.GetIndexes(systemType, direction.Value);
            if (indexes == null || indexes.Count == 0)
            {
                return null;
            }

            if(connectorStatus == Systems.ConnectorStatus.Undefined)
            {
                return new HashSet<int>(indexes);
            }

            HashSet<int> result = new HashSet<int>();
            foreach (int index in indexes)
            {
                ISystemConnection systemConnection = SystemConnection(systemPlantRoom, systemComponent, index);

                if((systemConnection == null && connectorStatus == Systems.ConnectorStatus.Unconnected) || (systemConnection != null && connectorStatus == Systems.ConnectorStatus.Connected))
                {
                    result.Add(index);
                }
            }

            return result;
        }
    }
}