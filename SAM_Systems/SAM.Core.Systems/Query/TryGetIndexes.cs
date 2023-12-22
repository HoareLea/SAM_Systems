using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        
        public static bool TryGetIndexes(this SystemPlantRoom systemPlantRoom, ISystem system, ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, int index_1, int index_2, out int index_1_out, out int index_2_out)
        {
            index_1_out = -1;
            index_2_out = -1;

            if(system == null || systemComponent_1 == null || systemComponent_2 == null)
            {
                return false;
            }

            SystemType systemType = new SystemType(system);

            SystemConnectorManager systemConnectorManager_1 = systemComponent_1.SystemConnectorManager;
            if(systemConnectorManager_1 == null || !systemConnectorManager_1.HasConnectors(systemType))
            {
                return false;
            }

            SystemConnectorManager systemConnectorManager_2 = systemComponent_2.SystemConnectorManager;
            if (systemConnectorManager_2 == null || !systemConnectorManager_2.HasConnectors(systemType))
            {
                return false;
            }

            List<int> indexes_1 = systemPlantRoom.Indexes(systemComponent_1, systemType, Systems.ConnectorStatus.Unconnected);
            if (indexes_1 == null || indexes_1.Count == 0)
            {
                return false;
            }

            List<int> indexes_2 = systemPlantRoom.Indexes(systemComponent_2, systemType, Systems.ConnectorStatus.Unconnected);
            if (indexes_2 == null || indexes_2.Count == 0)
            {
                return false;
            }

            if (index_1 != -1 && !indexes_1.Contains(index_1))
            {
                return false;
            }

            if (index_2 != -1 && !indexes_2.Contains(index_2))
            {
                return false;
            }

            if(index_1 != -1 && index_2 != -1)
            {
                Direction direction_1 = systemConnectorManager_1.GetDirection(index_1);
                Direction direction_2 = systemConnectorManager_2.GetDirection(index_2);

                if(direction_1 != Direction.Undefined && direction_1 == direction_2)
                {
                    return false;
                }

                index_1_out = index_1;
                index_2_out = index_2;
                return true;
            }

            if(index_1 == -1 && index_2 == -1)
            {
                foreach(int index_1_Temp in indexes_1)
                {
                    if (TryGetIndex(systemPlantRoom, system, systemComponent_2, systemConnectorManager_1, index_1_Temp, out index_2_out, false))
                    {
                        index_1_out = index_1_Temp;
                        return true;
                    }
                }

                foreach (int index_1_Temp in indexes_1)
                {
                    if (TryGetIndex(systemPlantRoom, system, systemComponent_2, systemConnectorManager_1, index_1_Temp, out index_2_out, true))
                    {
                        index_1_out = index_1_Temp;
                        return true;
                    }
                }

                return false;
            }

            if(index_1 != -1)
            {
                if (!TryGetIndex(systemPlantRoom, system, systemComponent_2, systemConnectorManager_1, index_1, out index_2_out, false))
                {
                    if (!TryGetIndex(systemPlantRoom, system, systemComponent_2, systemConnectorManager_1, index_1, out index_2_out, true))
                    {
                        return false;
                    }
                }

                index_1_out = index_1;
                return true;
            }

            if (index_2 != -1)
            {
                if(!TryGetIndex(systemPlantRoom, system, systemComponent_1, systemConnectorManager_2, index_2, out index_1_out, false))
                {
                    if(!TryGetIndex(systemPlantRoom, system, systemComponent_1, systemConnectorManager_2, index_2, out index_1_out, true))
                    {
                        return false;
                    }
                }

                index_2_out = index_2;
                return true;
            }

            return false;

        }
    }
}