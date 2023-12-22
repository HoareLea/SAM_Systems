using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        public static ConnectorStatus ConnectorStatus(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent, int index)
        {
            if(systemPlantRoom == null || systemComponent == null)
            {
                return Systems.ConnectorStatus.Undefined;
            }

            IEnumerable<int> indexes = systemComponent.SystemConnectorManager?.Indexes;
            if(indexes == null || !indexes.Contains(index))
            {
                return Systems.ConnectorStatus.Undefined;
            }

            ISystemConnection systemConnection = SystemConnection(systemPlantRoom, systemComponent, index);

            return systemConnection == null ? Systems.ConnectorStatus.Unconnected : Systems.ConnectorStatus.Connected;

        }
    }
}