using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static List<ISystemJSAMObject> RemoveSpace(this SystemPlantRoom systemPlantRoom, string name)
        {
            if(systemPlantRoom == null || name == null)
            {
                return null;
            }


            List<SystemSpace> systemSpaces_System = systemPlantRoom.GetSystemComponents<SystemSpace>();
            if(systemSpaces_System == null || systemSpaces_System.Count == 0)
            {
                return null;
            }

            SystemSpace systemSpace = systemSpaces_System.Find(x => x.Name == name);
            if (systemSpace == null)
            {
                return null;
            }

            List<AirSystemGroup> airSystemGroups = systemPlantRoom.GetRelatedObjects<AirSystemGroup>(systemSpace);
            if(airSystemGroups.Count == 0)
            {
                if (systemPlantRoom.Remove(systemSpace))
                {
                    return new List<ISystemJSAMObject>() { systemSpace };
                }
            }

            return null;
        }
    }
}