using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Geometry.Systems
{
    public static partial class Query
    {
        public static List<SystemComponent> TopSystemComponents(this SystemPlantRoom systemPlantRoom, IEnumerable<SystemComponent> systemComponents, SystemType systemType)
        {
            if(systemPlantRoom == null || systemComponents == null)
            {
                return null;
            }

            Dictionary<System.Guid, SystemComponent> dictionary = new Dictionary<System.Guid, SystemComponent>();
            foreach(SystemComponent systemComponent in systemComponents)
            {
                SystemComponent systemComponent_Temp = systemComponent;

                List<ISystemGroup> systemGroups = null;
                do
                {
                    systemGroups = systemPlantRoom.GetRelatedObjects<ISystemGroup>(systemComponent_Temp);
                    systemGroups?.RemoveAll(x => !(x is SystemComponent) || x.SystemType != systemType);

                    if(systemGroups != null && systemGroups.Count != 0)
                    {
                        systemComponent_Temp = systemGroups[0] as SystemComponent;
                    }
                }
                while (systemGroups != null && systemGroups.Count != 0);

                if(systemComponent_Temp == null)
                {
                    continue;
                }

                dictionary[systemComponent_Temp.Guid] = systemComponent_Temp;
            }

            return dictionary.Values.ToList();

        }
    }
}