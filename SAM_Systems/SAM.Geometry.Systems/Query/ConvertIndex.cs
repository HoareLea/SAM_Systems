using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        public static int ConvertIndex(this SystemConnectorManager systemConnectorManager, int index, DisplaySystemConnectorManager displaySystemConnectorManager)
        {
            if(systemConnectorManager == null || index == -1 || displaySystemConnectorManager == null)
            {
                return -1;
            }

            SystemConnector systemConnector = systemConnectorManager[index];
            if(systemConnector == null)
            {
                return -1;
            }

            List<int> indexes_Source = systemConnectorManager.GetIndexes(systemConnector.SystemType, systemConnector.Direction);
            if(indexes_Source == null || indexes_Source.Count == 0)
            {
                return -1;
            }

            List<int> indexes_Destination = displaySystemConnectorManager.GetIndexes(systemConnector.SystemType, systemConnector.Direction);
            if(indexes_Destination == null || indexes_Destination.Count == 0)
            {
                return -1;
            }

            int index_Temp = indexes_Source.IndexOf(index);

            if(indexes_Destination.Count < index_Temp)
            {
                return -1;
            }

            return indexes_Destination[index_Temp];

        }
    }
}