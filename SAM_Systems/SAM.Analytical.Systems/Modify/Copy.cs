using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static AirSystem Copy(this SystemPlantRoom systemPlantRoom_Source, SystemPlantRoom systemPlantRoom_Destination, AirSystem airSystem)
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

            List<ISystemJSAMObject> systemJSAMObjects = systemPlantRoom_Source.GetRelatedObjects<ISystemJSAMObject>(result);
            if (systemJSAMObjects == null || systemJSAMObjects.Count == 0)
            {
                return result;
            }

            List<ISystemConnection> systemConnections = new List<ISystemConnection>();

            List<ISystemGroup> systemGroups = new List<ISystemGroup>();

            foreach (ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
            {
                if (systemJSAMObject is ISystemConnection systemConnection)
                {
                    systemConnections.Add(systemConnection);
                }

                if(systemJSAMObject is ISystemGroup systemGroup)
                {
                    systemGroups.Add(systemGroup);
                }

                systemPlantRoom_Destination.Add(systemJSAMObject as dynamic);
                systemPlantRoom_Destination.Connect(result, systemJSAMObject as dynamic);
            }

            foreach(ISystemGroup systemGroup in systemGroups)
            {
                List<ISystemJSAMObject> systemJSAMObjects_SystemGroup = systemPlantRoom_Source.GetRelatedObjects<ISystemJSAMObject>(systemGroup);
                if (systemJSAMObjects_SystemGroup != null)
                {
                    foreach (ISystemJSAMObject systemJSAMObject_SystemGroup in systemJSAMObjects_SystemGroup)
                    {
                        TryConnect(systemPlantRoom_Destination, systemGroup, systemJSAMObject_SystemGroup);
                    }
                }
            }

            foreach (ISystemConnection systemConnection in systemConnections)
            {
                List<ISystemJSAMObject> systemJSAMObjects_SystemConnection = systemPlantRoom_Source.GetRelatedObjects<ISystemJSAMObject>(systemConnection);
                if(systemJSAMObjects_SystemConnection != null)
                {
                    foreach(ISystemJSAMObject systemJSAMObject_SystemConnection in systemJSAMObjects_SystemConnection)
                    {
                        systemPlantRoom_Destination.Connect(systemConnection, systemJSAMObject_SystemConnection as dynamic);
                    }
                }
            }

            return result;
        }

        //public static TSystemJSAMObject Copy<TSystemJSAMObject>(this SystemPlantRoom systemPlantRoom_Source, SystemPlantRoom systemPlantRoom_Destination, TSystemJSAMObject systemObject, List<TSystemJSAMObject> systemObjects) where TSystemJSAMObject : ISystemJSAMObject
        //{
        //    if(systemPlantRoom_Source is null || systemPlantRoom_Destination is null)
        //    {
        //        return default;
        //    }

        //    if(!(systemObject is ISAMObject sAMObject))
        //    {
        //        return default;
        //    }

        //    if(systemObjects != null)
        //    {
        //        if(systemObjects.Find(x => x is ISAMObject sAMObject_Temp && sAMObject_Temp.Guid == sAMObject.Guid) is TSystemJSAMObject systemComponent_Existing)
        //        {
        //            return systemComponent_Existing;
        //        }
        //    }

        //    TSystemJSAMObject result = systemPlantRoom_Source.GetSystemObject<TSystemJSAMObject>(x => x is ISAMObject sAMObject_Temp && sAMObject.Guid == sAMObject_Temp.Guid);
        //    if (result == null)
        //    {
        //        return default;
        //    }

        //    if(systemObjects is null)
        //    {
        //        systemObjects = new List<TSystemJSAMObject>();
        //    }

        //    systemObjects.Add(result);

        //    systemPlantRoom_Destination.Add(result as dynamic);

        //    List<ISystemComponent> systemComponents_Related = systemPlantRoom_Source.GetRelatedObjects<ISystemComponent>(result);
        //    if (systemComponents_Related == null || systemComponents_Related.Count == 0)
        //    {
        //        return result;
        //    }

        //    systemComponents_Related.Filter(out List<ISystemComponent> systemComponents_Connection, out List<ISystemComponent> systemComponents_Component, x => x is ISystemConnection);

        //    if(systemComponents_Component != null && systemComponents_Component.Count != 0)
        //    {
        //        foreach(ISystemComponent systemComponent_Component in systemComponents_Component)
        //        {
        //            if (!(systemObject is ISAMObject sAMObject_Component))
        //            {
        //                continue;
        //            }

        //            if (!(systemObjects.Find(x => x is ISAMObject sAMObject_Temp && sAMObject_Temp.Guid == sAMObject_Component.Guid) is ISystemComponent systemComponent_Component_Copy))
        //            {
        //                List<System.Guid> guid = new List<System.Guid>();

        //                systemComponent_Component_Copy = Copy(systemPlantRoom_Source, systemPlantRoom_Destination, (ISystemJSAMObject)systemComponent_Component, guid);
        //            }

        //            if(systemComponent_Component_Copy is null)
        //            {
        //                continue;
        //            }

        //            systemPlantRoom_Destination.Connect(systemComponent_Component_Copy, result as dynamic);
        //        }
        //    }

        //    if (systemComponents_Connection != null && systemComponents_Connection.Count != 0)
        //    {
        //        foreach (ISystemComponent systemComponent_Connection in systemComponents_Connection)
        //        {
        //            if(!(systemComponent_Connection is ISystemConnection systemConnection))
        //            {
        //                continue;
        //            }

        //            if (!(systemObject is ISAMObject sAMObject_Connection))
        //            {
        //                continue;
        //            }

        //            if (systemObjects.Find(x => x is ISAMObject sAMObject_Temp && sAMObject_Temp.Guid == sAMObject_Connection.Guid) is ISystemConnection systemConnection_Copy)
        //            {
        //                systemPlantRoom_Destination.Connect(systemConnection_Copy, result as dynamic);
        //            }
        //            else
        //            {
        //                systemPlantRoom_Destination.Connect(systemConnection, result as dynamic);
        //            }
        //        } 
        //    }

        //    return result;

        //}

        public static HashSet<Guid> Copy(this SystemPlantRoom systemPlantRoom_Destination, SystemPlantRoom systemPlantRoom_Source, ISystemJSAMObject systemJSAMObject)
        {
            return Copy(systemPlantRoom_Destination, systemPlantRoom_Source, systemJSAMObject, null, null);
        }

        public static HashSet<Guid> Copy(this SystemPlantRoom systemPlantRoom_Destination, SystemPlantRoom systemPlantRoom_Source, ISystemJSAMObject systemJSAMObject, IEnumerable<Guid> excludedGuids, IEnumerable<Type> excludedTypes)
        {
            if (systemPlantRoom_Destination == null || systemPlantRoom_Source == null || systemJSAMObject == null)
            {
                return null;
            }

            Guid guid = (systemJSAMObject as dynamic).Guid;

            if (excludedGuids != null && excludedGuids.Contains(guid))
            {
                return null;
            }

            systemPlantRoom_Destination.Add(systemJSAMObject as dynamic);

            HashSet<Guid> guids = excludedGuids == null ? new HashSet<Guid>() : new HashSet<Guid>(excludedGuids);
            guids.Add(guid);

            List<ISystemJSAMObject> systemJSAMObjects = systemPlantRoom_Source.GetRelatedObjects<ISystemJSAMObject>(systemJSAMObject);
            if (systemJSAMObjects != null && systemJSAMObjects.Count != 0)
            {
                List<ISystemConnection> systemConnetions = new List<ISystemConnection>();

                foreach (ISystemJSAMObject systemJSAMObject_Related in systemJSAMObjects)
                {
                    if (systemJSAMObject_Related == null)
                    {
                        continue;
                    }

                    if(excludedTypes != null)
                    {
                        if(excludedTypes.ToList().Find(x => x.IsAssignableFrom(systemJSAMObject_Related.GetType())) != null)
                        {
                            continue;
                        }
                    }

                    if (systemJSAMObject_Related is ISystemConnection)
                    {
                        systemConnetions.Add((ISystemConnection)systemJSAMObject_Related);
                        continue;
                    }

                    HashSet<Guid> guids_Temp = Copy(systemPlantRoom_Destination, systemPlantRoom_Source, systemJSAMObject_Related, guids, excludedTypes);

                    systemPlantRoom_Destination.TryConnect(systemJSAMObject, systemJSAMObject_Related);

                    if (guids_Temp == null)
                    {
                        continue;
                    }

                    foreach (Guid guid_Temp in guids_Temp)
                    {
                        guids.Add(guid_Temp);
                    }
                }

                foreach (ISystemConnection systemConnection in systemConnetions)
                {
                    List<ObjectReference> objectReferences = systemConnection?.ObjectReferences;
                    if (objectReferences == null || objectReferences.Count == 0)
                    {
                        continue;
                    }

                    foreach (ObjectReference objectReference in objectReferences)
                    {
                        ISystemJSAMObject systemJSAMObject_Temp = systemPlantRoom_Destination.GetSystemObject<ISystemJSAMObject>(objectReference);
                        if (systemJSAMObject_Temp != null)
                        {
                            TryConnect(systemPlantRoom_Destination, systemConnection, systemJSAMObject_Temp);
                        }
                    }

                    systemPlantRoom_Destination.TryConnect(systemJSAMObject, systemConnection);
                }
            }

            return guids;
        }
    }
}