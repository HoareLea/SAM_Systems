using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        public static bool TryGetIndex(this SystemPlantRoom systemPlantRoom, ISystem system, ISystemComponent systemComponent, SystemConnectorManager systemConnectorManager, int index_SystemConnectorManager, out int index_SystemComponent, bool includeSystemType)
        {
            index_SystemComponent = -1;

            if(systemPlantRoom == null)
            {
                return false;
            }

            Direction direction = systemConnectorManager.GetDirection(index_SystemConnectorManager);

            List<Direction> directions = new List<Direction>() { direction.Opposite() };
            if (direction == Direction.Undefined)
            {
                directions.Add(Direction.In);
                directions.Add(Direction.Out);
            }
            else
            {
                directions.Add(Direction.Undefined);
            }

            foreach (Direction direction_Temp in directions)
            {
                List<int> indexes = systemPlantRoom.Indexes(systemComponent, system, Systems.ConnectorStatus.Unconnected, direction_Temp, includeSystemType);
                if (indexes != null && indexes.Count != 0)
                {
                    index_SystemComponent = indexes[0];
                    return true;
                }
            }

            return false;
        }
    }
}