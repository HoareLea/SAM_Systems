using SAM.Analytical.Enums;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;

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

            Dictionary<string, List<Space>> dictionary_Space = new Dictionary<string, List<Space>>();
            foreach (Space space in spaces)
            {
                if (space is null)
                {
                    continue;
                }

                string key = string.Empty;

                PartFSpaceData partFSpaceData = space.GetValue<PartFSpaceData>(SpaceParameter.PartFSpaceData);
                if (partFSpaceData != null)
                {
                    key = partFSpaceData.PartFVentilationType.ToString();
                }

                if (!dictionary_Space.TryGetValue(key, out List<Space> spaces_Key))
                {
                    spaces_Key = new List<Space>();
                    dictionary_Space[key] = spaces_Key;
                }

                spaces_Key.Add(space);
            }

            Dictionary<string, SystemSpace> dictionary_SystemSpace = new Dictionary<string, SystemSpace>();
            foreach (Tuple<string, SystemSpace> tuple_Temp in tuples)
            {
                string key = tuple_Temp.Item1 ?? string.Empty;

                if (Core.Query.TryConvert(key, out PartFVentilationType partFVentilationType))
                {
                    key = partFVentilationType.ToString();
                }
                else
                {
                    key = string.Empty;
                }

                dictionary_SystemSpace[key] = tuple_Temp.Item2;
            }

            foreach (KeyValuePair<string, List<Space>> keyValuePair in dictionary_Space)
            {
                if (!dictionary_SystemSpace.TryGetValue(keyValuePair.Key, out SystemSpace systemSpace) || systemSpace is null)
                {
                    if (!dictionary_SystemSpace.TryGetValue(string.Empty, out systemSpace) || systemSpace is null)
                    {
                        continue;
                    }
                }

                if (systemSpace is null)
                {
                    continue;
                }

                foreach (Space space in keyValuePair.Value)
                {
                    systemPlantRoom.Duplicate(systemSpace, space);
                }
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

            HashSet<Guid> guids = Copy(systemPlantRoom_Destination, systemPlantRoom_Source, (ISystemJSAMObject)airSystem, new List<Guid>(), new List<Type>() { typeof(Core.Systems.ISystem) });
            if(guids == null || guids.Count == 0)
            {
                return null;
            }

            airSystem = UpdateAirSystem(systemPlantRoom_Destination, airSystem, spaces);

            return guids == null || guids.Count == 0 ? null : airSystem;
        }


    }
}