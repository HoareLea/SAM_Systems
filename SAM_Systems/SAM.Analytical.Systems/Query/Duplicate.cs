using SAM.Core;
using SAM.Core.Systems;
using SAM.Geometry.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static SystemSpace Duplicate(this SystemPlantRoom systemPlantRoom, SystemSpace systemSpace, Space space)
        {
            if(systemPlantRoom == null || systemSpace == null || space == null)
            {
                return null;
            }

            SystemSpace result = systemPlantRoom.GetSystemComponent<SystemSpace>(new ObjectReference(systemSpace));

            DisplaySystemSpace displaySystemSpace = result as DisplaySystemSpace;

            double area = double.NaN;
            if (space.TryGetValue(SpaceParameter.Area, out double area_Temp))
            {
                area = area_Temp;
            }

            double volume = double.NaN;
            if (space.TryGetValue(SpaceParameter.Volume, out double volume_Temp))
            {
                volume = volume_Temp;
            }

            result = new SystemSpace(space.Name, area, volume, double.NaN, double.NaN);


            if (displaySystemSpace != null)
            {
                SystemGeometryInstance systemGeometryInstance = displaySystemSpace.SystemGeometry;

                result = new DisplaySystemSpace(result, systemGeometryInstance?.SystemGeometrySymbol, systemGeometryInstance?.CoordinateSystem2D?.Origin);
            }

            systemPlantRoom.Add(result);

            List<ISystemJSAMObject> systemJSAMObjects = systemPlantRoom.GetRelatedObjects(systemSpace);
            if(systemJSAMObjects != null && systemJSAMObjects.Count != 0)
            {
                foreach(ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
                {
                    if(systemJSAMObject is ISystemConnection)
                    {
                        ISystemConnection systemConnection_Old = (ISystemConnection)systemJSAMObject;

                        ISystemConnection systemConnection_New = Duplicate(systemPlantRoom, systemConnection_Old, systemSpace, result);
                        systemPlantRoom.Connect(systemConnection_New, systemPlantRoom.GetRelatedObjects<Core.Systems.ISystem>(systemConnection_Old).FirstOrDefault());
                    }
                    else if(systemJSAMObject is Core.Systems.ISystem)
                    {
                        systemPlantRoom.Connect((Core.Systems.ISystem)systemJSAMObject, result);
                    }
                    else if (systemJSAMObject is ISystemGroup)
                    {
                        systemPlantRoom.Connect((ISystemGroup)systemJSAMObject, result);
                    }
                }
            }

            return result;
        }

        public static ISystemConnection Duplicate(this SystemPlantRoom systemPlantRoom, ISystemConnection systemConnection, ISystemComponent systemComponent_Old, ISystemComponent systemComponent_New)
        {
            if(systemConnection == null || systemComponent_Old == null || systemComponent_New == null)
            {
                return null;
            }

            List<Tuple<ObjectReference, int>> tuples = new List<Tuple<ObjectReference, int>>();

            ObjectReference objectReference_Old = new ObjectReference((SAMObject)systemComponent_Old);

            List<ObjectReference> objectReferences = systemConnection.ObjectReferences;
            if(objectReferences != null)
            {
                foreach (ObjectReference objectReference in objectReferences)
                {
                    if(systemConnection.TryGetIndex(objectReference, out int index))
                    {
                        ObjectReference objectReference_Temp = objectReference;
                        if(objectReference_Old == objectReference_Temp)
                        {
                            objectReference_Temp = new ObjectReference((SAMObject)systemComponent_New);
                        }

                        tuples.Add(new Tuple<ObjectReference, int>(objectReference_Temp, index));
                    }
                }
            }

            SystemConnection result = new SystemConnection(systemConnection.SystemType, tuples);

            if(systemConnection is DisplaySystemConnection)
            {
                DisplaySystemConnection displaySystemConnection = (DisplaySystemConnection)systemConnection;

                result = new DisplaySystemConnection(result, displaySystemConnection.SystemGeometry?.Points?.ToArray());
            }

            systemPlantRoom.Add(result);

            return result;
        }
    }
}