using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        private static bool TryConnect(this SystemPlantRoom systemPlantRoom, ISystemJSAMObject systemJSAMObject_1, ISystemJSAMObject systemJSAMObject_2)
        {
            if(systemPlantRoom == null || systemJSAMObject_1 == null || systemJSAMObject_2 == null)
            {
                return false;
            }

            if(systemJSAMObject_1 is ISystemSpaceComponent && systemJSAMObject_2 is ISystemSpace)
            {
                return systemPlantRoom.Connect((ISystemSpaceComponent)systemJSAMObject_1, (ISystemSpace)systemJSAMObject_2);
            }
            
            if (systemJSAMObject_1 is ISystemSpace && systemJSAMObject_2 is ISystemSpaceComponent)
            {
                return systemPlantRoom.Connect((ISystemSpaceComponent)systemJSAMObject_2, (ISystemSpace)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystemComponentResult && systemJSAMObject_2 is ISystemComponent)
            {
                return systemPlantRoom.Connect((ISystemComponentResult)systemJSAMObject_1, (ISystemComponent)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemComponent && systemJSAMObject_2 is ISystemComponentResult)
            {
                return systemPlantRoom.Connect((ISystemComponentResult)systemJSAMObject_2, (ISystemComponent)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystemSpaceResult && systemJSAMObject_2 is ISystemSpace)
            {
                return systemPlantRoom.Connect((ISystemSpaceResult)systemJSAMObject_1, (ISystemSpace)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemSpace && systemJSAMObject_2 is ISystemSpaceResult)
            {
                return systemPlantRoom.Connect((ISystemSpaceResult)systemJSAMObject_2, (ISystemSpace)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystem && systemJSAMObject_2 is ISystemConnection)
            {
                return systemPlantRoom.Connect((ISystem)systemJSAMObject_1, (ISystemConnection)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemConnection && systemJSAMObject_2 is ISystem)
            {
                return systemPlantRoom.Connect((ISystem)systemJSAMObject_2, (ISystemConnection)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystem && systemJSAMObject_2 is ISystemComponent)
            {
                return systemPlantRoom.Connect((ISystem)systemJSAMObject_1, (ISystemComponent)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemComponent && systemJSAMObject_2 is ISystem)
            {
                return systemPlantRoom.Connect((ISystem)systemJSAMObject_2, (ISystemComponent)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystemGroup && systemJSAMObject_2 is ISystemComponent)
            {
                return systemPlantRoom.Connect((ISystemGroup)systemJSAMObject_1, (ISystemComponent)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemComponent && systemJSAMObject_2 is ISystemGroup)
            {
                return systemPlantRoom.Connect((ISystemGroup)systemJSAMObject_2, (ISystemComponent)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystemControl && systemJSAMObject_2 is ISystemConnection)
            {
                return systemPlantRoom.Connect((ISystemControl)systemJSAMObject_1, (ISystemConnection)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemConnection && systemJSAMObject_2 is ISystemControl)
            {
                return systemPlantRoom.Connect((ISystemControl)systemJSAMObject_2, (ISystemConnection)systemJSAMObject_1);
            }

            if (systemJSAMObject_1 is ISystemConnection && systemJSAMObject_2 is ISystemComponent)
            {
                return systemPlantRoom.Connect((ISystemConnection)systemJSAMObject_1, (ISystemComponent)systemJSAMObject_2);
            }

            if (systemJSAMObject_1 is ISystemComponent && systemJSAMObject_2 is ISystemConnection)
            {
                return systemPlantRoom.Connect((ISystemConnection)systemJSAMObject_2, (ISystemComponent)systemJSAMObject_1);
            }

            return false;
        }
    }
}