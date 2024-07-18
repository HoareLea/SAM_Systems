using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static List<T> CleanSystems<T>(this SystemPlantRoom systemPlantRoom, List<T> systems = null) where T : ISystem
        {
            if(systemPlantRoom == null)
            {
                return null;
            }

            if(systems == null)
            {
                systems = systemPlantRoom.GetSystems<T>();
            }

            List<T> result = new List<T>();

            foreach(T system in systems)
            {
                if(system == null)
                {
                    continue;
                }

                T airSystem_Temp = systemPlantRoom.GetSystem<T>(x => x.Guid == system.Guid);
                if(airSystem_Temp == null)
                {
                    continue;
                }

                List<ISystemSpace> systemSpaces = systemPlantRoom.GetSystemComponents<ISystemSpace>(airSystem_Temp);
                if(systemSpaces != null && systemSpaces.Count != 0)
                {
                    continue;
                }

                List<ISystemComponent> systemComponents = systemPlantRoom.GetSystemComponents<ISystemComponent>();
                if(systemComponents == null || systemComponents.Count == 0)
                {
                    continue;
                }

                foreach(ISystemComponent systemComponent in systemComponents)
                {
                    List<T> systems_SystemComponent = systemPlantRoom.GetSystems<T>(systemComponent);
                    if(systems_SystemComponent == null || (systems_SystemComponent.Count == 1 && systems_SystemComponent.Find(x => x.Guid == system.Guid) != null))
                    {
                        systemPlantRoom.Remove(systemComponent);
                    }
                }

                systemPlantRoom.Remove(system);
                result.Add(system);
            }

            return result;
        }
    }
}