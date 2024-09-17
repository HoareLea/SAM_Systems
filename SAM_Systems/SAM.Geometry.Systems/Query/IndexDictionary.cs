using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        /// <summary>
        /// Returns dictionary of conector Ids where key is systemObject index and value is systemGeometry connector index
        /// </summary>
        /// <param name="systemPlantRoom">SystemPlantRoom</param>
        /// <param name="displaySystemObject">DisplaySystemObject</param>
        /// <param name="systemType">SystemType</param>
        /// <param name="connectorStatus">ConnectorStatus</param>
        /// <param name="direction">Direction</param>
        /// <returns>Dictionary of conector Ids where key is systemObject index and value is systemGeometry connector index</returns>
        public static Dictionary<int, int> IndexDictionary(this SystemPlantRoom systemPlantRoom, IDisplaySystemObject<SystemGeometryInstance> displaySystemObject, SystemType systemType, ConnectorStatus connectorStatus = Core.Systems.ConnectorStatus.Undefined, Core.Direction? direction = null)
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

            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach(int index in indexes)
            {
                int index_Temp = ConvertIndex(systemComponent.SystemConnectorManager, index, displaySystemObject.SystemGeometry.SystemGeometrySymbol.DisplaySystemConnectorManager);
                if(index_Temp != -1)
                {
                    result[index] = index_Temp;
                }
            }

            return result;
        }
    }
}