using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        
        public static HashSet<int> FindIndexes(this SystemPlantRoom systemPlantRoom, IDisplaySystemObject<SystemGeometryInstance> displaySystemObject, SystemType systemType, ConnectorStatus connectorStatus = Core.Systems.ConnectorStatus.Undefined, Core.Direction? direction = null)
        {
            ISystemComponent systemComponent = displaySystemObject as ISystemComponent;
            if(systemComponent == null)
            {
                return null;
            }

            HashSet<int> indexes = Core.Systems.Query.FindIndexes(systemPlantRoom, systemComponent, systemType, connectorStatus, direction);
            if (indexes == null || indexes.Count == 0)
            {
                return null;
            }

            HashSet<int> result = new HashSet<int>();
            foreach(int index in indexes)
            {
                int index_Temp = ConvertIndex(systemComponent.SystemConnectorManager, index, displaySystemObject.SystemGeometry.SystemGeometrySymbol.DisplaySystemConnectorManager);
                if(index_Temp != -1)
                {
                    result.Add(index_Temp);
                }
            }

            return result;
        }
    }
}