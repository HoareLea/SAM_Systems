using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public static partial class Query
    {
        
        public static List<T> SystemComponents<T>(this SystemPlantRoom systemPlantRoom, SystemConnection systemConnection) where T: ISystemComponent
        {
            if(systemPlantRoom == null || systemConnection == null)
            {
                return null;
            }

            List<ObjectReference> objectReferences = systemConnection.ObjectReferences;
            if(objectReferences == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach(ObjectReference objectReference in objectReferences)
            {
                T t = systemPlantRoom.GetSystemComponent<T>(objectReference);
                if(t != null)
                {
                    result.Add(t);
                }
            }

            return result;
        }
    }
}