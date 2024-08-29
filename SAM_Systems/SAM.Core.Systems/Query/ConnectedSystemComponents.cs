using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public static partial class Query
    {

        public static List<ISystemComponent> ConnectedSystemComponents<T>(SystemPlantRoom systemPlantRoom, ISystem system, SystemGroup<T> systemGroup, ISystemComponent systemComponent) where T : ISystem
        {
            if (systemPlantRoom == null || systemGroup == null || systemComponent == null)
            {
                return null;
            }

            System.Guid guid = systemPlantRoom.GetGuid(systemComponent);
            if(guid == System.Guid.Empty)
            {
                return null;
            }

            List<SystemGroup<T>> systemGroups = systemPlantRoom.GetRelatedObjects<SystemGroup<T>>(systemComponent);
            if (systemGroups == null || systemGroups.Find(x => x.Guid == systemGroup.Guid) == null)
            {
                return null;
            }

            List<ISystemComponent> result = new List<ISystemComponent>(); 

            List<ISystemComponent> systemComponents_In = systemPlantRoom.GetOrderedSystemComponents(systemComponent, system, Direction.In);
            if(systemComponents_In != null)
            {
                systemComponents_In.Reverse();
                foreach (ISystemComponent systemComponent_Temp in systemComponents_In)
                {
                    SystemComponent systemComponent_Temp_Temp = systemComponent_Temp as SystemComponent;
                    if (systemComponent_Temp_Temp == null)
                    {
                        continue;
                    }

                    systemGroups = systemPlantRoom.GetRelatedObjects<SystemGroup<T>>(systemComponent_Temp_Temp);
                    if (systemGroups == null || systemGroups.Find(x => x.Guid == systemGroup.Guid) == null)
                    {
                        continue;
                    }

                    result.Add(systemComponent_Temp_Temp);
                }
            }

            List<ISystemComponent> systemComponents_Out = systemPlantRoom.GetOrderedSystemComponents(systemComponent, system, Direction.Out);
            if (systemComponents_Out != null)
            {
                foreach (ISystemComponent systemComponent_Temp in systemComponents_Out)
                {
                    systemGroups = systemPlantRoom.GetRelatedObjects<SystemGroup<T>>(systemComponent_Temp);
                    if (systemGroups == null || systemGroups.Find(x => x.Guid == systemGroup.Guid) == null)
                    {
                        continue;
                    }

                    result.Add(systemComponent_Temp);
                }
            }

            return result;

        }
    }
}