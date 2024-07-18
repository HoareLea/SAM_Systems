using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static List<SystemSpace> RemoveSpaces(this SystemPlantRoom systemPlantRoom, ISystem system, IEnumerable<string> names)
        {
            if(systemPlantRoom == null || system == null || names == null)
            {
                return null;
            }


            List<SystemSpace> systemSpaces_System = systemPlantRoom.GetSystemComponents<SystemSpace>(system);
            if(systemSpaces_System == null || systemSpaces_System.Count == 0)
            {
                return null;
            }

            List<SystemSpace> result = new List<SystemSpace>();
            foreach(string name in names)
            {
                SystemSpace systemSpace_System = systemSpaces_System.Find(x => x.Name == name);
                if(systemSpace_System == null)
                {
                    continue;
                }

                if(systemPlantRoom.Remove(systemSpace_System))
                {
                    result.Add(systemSpace_System);
                }
            }

            return result;
        }
    }
}