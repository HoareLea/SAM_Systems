using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        
        public static ISystemConnection SystemConnection(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent, int index)
        {
            List<ISystemConnection> systemConnetctions = systemPlantRoom?.GetRelatedObjects<ISystemConnection>(systemComponent);
            if(systemConnetctions == null || systemConnetctions.Count == 0)
            {
                return null;
            }

            return SystemConnection(systemConnetctions, systemComponent, index);
        }
        
        public static ISystemConnection SystemConnection(this IEnumerable<ISystemConnection> systemConnections, ISystemComponent systemComponent, int index)
        { 
            if (systemConnections == null || systemConnections.Count() == 0 || systemComponent == null)
            {
                return null;
            }

            foreach (ISystemConnection systemConnection in systemConnections)
            {
                SystemType systemType_Temp = systemConnection?.SystemType;
                if (systemType_Temp == null)
                {
                    continue;
                }

                if (!systemConnection.TryGetIndex(systemComponent, out int index_Temp))
                {
                    continue;
                }

                if (index_Temp != index)
                {
                    continue;
                }

                return systemConnection;
            }

            return null;
        }
    }
}