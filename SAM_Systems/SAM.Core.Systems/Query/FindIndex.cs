using System.Collections.Generic;
using System.Linq;

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

            HashSet<int> indexes = FindIndexes(systemPlantRoom, systemComponent, systemType, connectorStatus, direction);
            if(indexes == null || indexes.Count == 0)
            {
                return -1;
            }

            return indexes.First();
        }
    }
}