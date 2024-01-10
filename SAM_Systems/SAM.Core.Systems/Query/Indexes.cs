using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        
        public static List<int> Indexes(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent, SystemType systemType, ConnectorStatus connectorStatus, Direction? direction = null)
        {
            if (systemPlantRoom == null || systemComponent == null)
            {
                return null;
            }

            List<int> indexes = direction == null  || !direction.HasValue ? systemComponent.SystemConnectorManager?.GetIndexes(systemType) : systemComponent.SystemConnectorManager?.GetIndexes(systemType, direction.Value);
            if (indexes == null)
            {
                return null;
            }

            if(connectorStatus == Systems.ConnectorStatus.Undefined)
            {
                return indexes;
            }

            List<int> result = new List<int>();
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

        public static List<int> Indexes(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent, ISystem system, ConnectorStatus connectorStatus, Direction? direction = null, bool includeSystemType = true)
        {
            if (systemPlantRoom == null || systemComponent == null)
            {
                return null;
            }

            SystemConnectorManager systemConnectorManager = systemComponent.SystemConnectorManager;
            if(systemConnectorManager == null)
            {
                return null;
            }

            SystemType systemType = new SystemType(system);

            List<int> indexes = direction == null || !direction.HasValue ? systemConnectorManager.GetIndexes(systemType) : systemConnectorManager.GetIndexes(systemType, direction.Value);
            if (indexes == null)
            {
                return null;
            }

            if (connectorStatus == Systems.ConnectorStatus.Undefined)
            {
                return indexes;
            }

            System.Guid guid = systemPlantRoom.GetGuid(system);

            List<int> result = new List<int>();
            foreach (int index in indexes)
            {
                ISystemConnection systemConnection;

                systemConnection = SystemConnection(systemPlantRoom, systemComponent, index);

                if (!((systemConnection == null && connectorStatus == Systems.ConnectorStatus.Unconnected) || (systemConnection != null && connectorStatus == Systems.ConnectorStatus.Connected)))
                {
                    continue;
                }

                List<int> connectedIndexes = systemConnectorManager.GetConnectedIndexes(index);
                if (connectedIndexes == null || connectedIndexes.Count == 0)
                {
                    continue;
                }

                foreach(int connectedIndex in connectedIndexes)
                {
                    systemConnection = SystemConnection(systemPlantRoom, systemComponent, connectedIndex);
                    if(systemConnection == null)
                    {
                        continue;
                    }

                    List<ISystem> systems = systemPlantRoom.GetRelatedObjects<ISystem>(systemConnection);
                    if(systems == null || systems.Count == 0)
                    {
                        continue;
                    }

                    foreach(ISystem system_Temp in systems)
                    {
                        System.Guid guid_Temp = systemPlantRoom.GetGuid(system_Temp);

                        if(guid == guid_Temp)
                        {
                            result.Add(index);
                            break;
                        }
                    }
                }
            }


            if(!includeSystemType || (result != null && result.Count != 0))
            {
                return result;
            }

            return Indexes(systemPlantRoom, systemComponent, systemType, connectorStatus, direction);
        }
    }
}