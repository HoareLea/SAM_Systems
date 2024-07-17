using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static AirSystem UpdateAirSystem(this SystemEnergyCentre systemEnergyCentre, AirSystem airSystem, IEnumerable<Space> spaces)
        {
            if (systemEnergyCentre == null || airSystem == null || spaces == null)
            {
                return null;
            }

            if(!systemEnergyCentre.TryGetSystem(airSystem.Guid, out SystemPlantRoom systemPlantRoom, out AirSystem result))
            {
                return null;
            }

            return UpdateAirSystem(systemPlantRoom, airSystem, spaces);

        }

        public static AirSystem UpdateAirSystem(this SystemPlantRoom systemPlantRoom, AirSystem airSystem, IEnumerable<Space> spaces)
        {
            if (systemPlantRoom == null || airSystem == null || spaces == null)
            {
                return null;
            }

            AirSystem result = systemPlantRoom.GetSystem<AirSystem>(x => x.Guid == airSystem.Guid);
            if(result == null)
            {
                return result;
            }

            List<SystemSpace> systemSpaces = systemPlantRoom.GetRelatedObjects<SystemSpace>(result);
            if(systemSpaces == null || systemSpaces.Count == 0)
            {
                return result;
            }


            List<Tuple<string, SystemSpace>> tuples = new List<Tuple<string, SystemSpace>>();
            foreach (SystemSpace systemSpace in systemSpaces)
            {
                List<AirSystemGroup> airSystemGroups = systemPlantRoom.GetRelatedObjects<AirSystemGroup>(systemSpace);
                if (airSystemGroups == null || airSystemGroups.Count == 0)
                {
                    tuples.Add(new Tuple<string, SystemSpace>(null, systemSpace));
                    continue;
                }

                airSystemGroups.ForEach(x => tuples.Add(new Tuple<string, SystemSpace>(x.Name, systemSpace)));
            }

            bool single = tuples.ConvertAll(x => x.Item1).FindAll(x => !string.IsNullOrEmpty(x)).Distinct().Count() <= 1;
            if (single)
            {
                SystemSpace systemSpace = tuples.First().Item2;

                foreach (Space space in spaces)
                {
                    systemPlantRoom.Duplicate(systemSpace, space);
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            tuples.ForEach(x => systemPlantRoom.Remove(x.Item2));

            return result;

        }

        public static AirSystem UpdateAirSystem(this SystemPlantRoom systemPlantRoom_Destination, SystemPlantRoom systemPlantRoom_Source, AirSystem airSystem_Source, IEnumerable<Space> spaces)
        {
            if(systemPlantRoom_Destination == null || systemPlantRoom_Source == null || airSystem_Source == null)
            {
                return null;
            }

            AirSystem airSystem = systemPlantRoom_Source.GetSystem<AirSystem>(x => x.Guid == airSystem_Source.Guid);
            if (airSystem == null)
            {
                return null;
            }

            HashSet<Guid> guids = Copy(systemPlantRoom_Destination, systemPlantRoom_Source, (ISystemJSAMObject)airSystem);
            if(guids == null || guids.Count == 0)
            {
                return null;
            }

            airSystem = UpdateAirSystem(systemPlantRoom_Destination, airSystem, spaces);

            return guids == null || guids.Count == 0 ? null : airSystem;
        }

        private static HashSet<Guid> Copy(this SystemPlantRoom systemPlantRoom_Destination, SystemPlantRoom systemPlantRoom_Source, ISystemJSAMObject systemJSAMObject)
        {
            return Copy(systemPlantRoom_Destination, systemPlantRoom_Source, systemJSAMObject, null);
        }

        private static HashSet<Guid> Copy(this SystemPlantRoom systemPlantRoom_Destination, SystemPlantRoom systemPlantRoom_Source, ISystemJSAMObject systemJSAMObject, IEnumerable<Guid> excludedGuids)
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
            if(systemJSAMObjects != null && systemJSAMObjects.Count != 0)
            {
                List<ISystemConnection> systemConnetions = new List<ISystemConnection>();

                foreach(ISystemJSAMObject systemJSAMObject_Related in systemJSAMObjects)
                {
                    if(systemJSAMObject_Related == null)
                    {
                        continue;
                    }

                    if(systemJSAMObject_Related is ISystemConnection)
                    {
                        systemConnetions.Add((ISystemConnection)systemJSAMObject_Related);
                        continue;
                    }

                    HashSet<Guid> guids_Temp = Copy(systemPlantRoom_Destination, systemPlantRoom_Source, systemJSAMObject_Related, guids);
                    
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