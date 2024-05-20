using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static bool ContainsSystemSpace(this SystemPlantRoom systemPlantRoom, ISystemGroup systemGroup)
        {
            if(systemPlantRoom == null || systemGroup == null)
            {
                return false;
            }

            List<ISystemComponent> systemComponents = systemPlantRoom.GetRelatedObjects<ISystemComponent>(systemGroup);
            if(systemComponents == null || systemComponents.Count == 0)
            {
                return false;
            }

            if(systemComponents.Find(x => x is ISystemSpace) != null)
            {
                return true;
            }

            foreach(ISystemComponent systemComponent in systemComponents)
            {
                if(systemComponent is ISystemGroup && ContainsSystemSpace(systemPlantRoom, (ISystemGroup)systemComponent))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsSystemSpace(this SystemPlantRoom systemPlantRoom, ISystemComponent systemComponent)
        {
            if (systemPlantRoom == null || systemComponent == null)
            {
                return false;
            }

            if(systemComponent is ISystemSpace)
            {
                return true;
            }

            if(systemComponent is ISystemGroup)
            {
                return ContainsSystemSpace(systemPlantRoom, (ISystemGroup)systemComponent);
            }

            return false;
        }
    }
}