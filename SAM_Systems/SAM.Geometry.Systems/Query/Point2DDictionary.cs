using SAM.Core;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        public static Dictionary<int, Point2D> Point2DDictionary(this SystemPlantRoom systemPlantRoom, IDisplaySystemObject<SystemGeometryInstance> displaySystemObject, SystemType systemType, ConnectorStatus connectorStatus = ConnectorStatus.Undefined, Direction? direction = null)
        {
            if(systemPlantRoom == null || displaySystemObject == null || systemType == null)
            {
                return null;
            }

            Dictionary<int, int> dictionary = IndexDictionary(systemPlantRoom, displaySystemObject, systemType, connectorStatus, direction);
            if (dictionary == null || dictionary.Count == 0)
            {
                return null;
            }

            Dictionary<int, Point2D> result = new Dictionary<int, Point2D>();
            foreach(KeyValuePair<int, int> keyValuePair in dictionary)
            {
                Point2D point2D = (displaySystemObject as dynamic).SystemGeometry.GetPoint2D(keyValuePair.Value);
                if (point2D == null)
                {
                    continue;
                }

                result[keyValuePair.Key] = point2D;
            }

            return result;
        }
    }
}