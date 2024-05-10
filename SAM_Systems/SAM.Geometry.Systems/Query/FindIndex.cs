using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        public static bool TryGetIndexes(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, out int index_1, out int index_2, SystemType systemType, Direction direction)
        {
            index_1 = -1;
            index_2 = -1;

            if (systemPlantRoom == null || systemComponent_1 == null || systemComponent_2 == null)
            {
                return false;
            }

            HashSet<int> indexes_1 = Core.Systems.Query.FindIndexes(systemPlantRoom, systemComponent_1, systemType, ConnectorStatus.Unconnected, direction);
            if(indexes_1 == null || indexes_1.Count == 0)
            {
                return false;
            }

            HashSet<int> indexes_2 = Core.Systems.Query.FindIndexes(systemPlantRoom, systemComponent_2, systemType, ConnectorStatus.Unconnected, direction.Opposite());
            if (indexes_2 == null || indexes_2.Count == 0)
            {
                return false;
            }

            if (indexes_1.Count == 1 && indexes_2.Count == 1)
            {
                index_1 = indexes_1.First();
                index_2 = indexes_2.First();
                return true;
            }

            SystemGeometryInstance systemGeometryInstance_1 = ((IDisplaySystemObject<SystemGeometryInstance>)systemComponent_1).SystemGeometry;
            if(systemGeometryInstance_1 == null)
            {
                index_1 = indexes_1.First();
                index_2 = indexes_2.First();
                return true;
            }

            SystemGeometryInstance systemGeometryInstance_2 = ((IDisplaySystemObject<SystemGeometryInstance>)systemComponent_2).SystemGeometry;
            if (systemGeometryInstance_2 == null)
            {
                index_1 = indexes_1.First();
                index_2 = indexes_2.First();
                return true;
            }

            double distance = double.MaxValue;

            foreach(int index_1_Temp in indexes_1)
            {
                DisplaySystemConnector displaySystemConnector_1 = systemGeometryInstance_1.GetDisplaySystemConnector(index_1_Temp);
                foreach (int index_2_Temp in indexes_2)
                {
                    DisplaySystemConnector displaySystemConnector_2 = systemGeometryInstance_2.GetDisplaySystemConnector(index_2_Temp);

                    double distance_Temp = displaySystemConnector_1.Location.Distance(displaySystemConnector_2.Location);

                    if (distance_Temp < distance)
                    {
                        distance = distance_Temp;
                        index_1 = index_1_Temp;
                        index_2 = index_2_Temp;
                    }
                }
            }

            return index_1 != -1 && index_2 != -1;
        }
    }
}