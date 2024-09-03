using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        private static AirSystem Copy(this SystemPlantRoom systemPlantRoom_Source, SystemPlantRoom systemPlantRoom_Destination, AirSystem airSystem)
        {
            if (systemPlantRoom_Source == null || airSystem == null || systemPlantRoom_Destination == null || airSystem == null)
            {
                return null;
            }

            AirSystem result = systemPlantRoom_Source.GetSystems<AirSystem>().Find(x => x.Name == airSystem.Name)?.Clone();
            if (result == null)
            {
                return null;
            }

            systemPlantRoom_Destination.Add(result);

            List<ISystemComponent> systemComponents = systemPlantRoom_Source.GetRelatedObjects<ISystemComponent>(result);
            if (systemComponents != null)
            {
                foreach (ISystemComponent systemComponent in systemComponents)
                {
                    if (systemComponent is ISystemConnection)
                    {
                        continue;
                    }

                    systemPlantRoom_Destination.Add(systemComponent);
                    systemPlantRoom_Destination.Connect(result, systemComponent);
                }

                foreach (ISystemComponent systemComponent in systemComponents)
                {
                    if (systemComponent is ISystemConnection)
                    {
                        systemPlantRoom_Destination.Connect((ISystemConnection)systemComponent, result);
                        continue;
                    }

                    List<ISystemComponent> systemComponents_Related = systemPlantRoom_Source.GetRelatedObjects<ISystemComponent>(systemComponent);
                    if (systemComponents_Related == null)
                    {
                        continue;
                    }

                    foreach (ISystemComponent systemComponent_Related in systemComponents_Related)
                    {
                        if (systemComponent_Related is ISystemGroup)
                        {
                            systemPlantRoom_Destination.Connect((ISystemGroup)systemComponent_Related, systemComponent);
                        }
                    }
                }
            }

            return result;
        }
    }
}