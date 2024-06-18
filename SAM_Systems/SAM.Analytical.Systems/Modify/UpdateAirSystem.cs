using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        private static AirSystem UpdateAirSystem(this AnalyticalModel analyticalModel, IEnumerable<Space> spaces, SystemPlantRoom systemPlantRoom, AirSystem airSystem)
        {
            if (analyticalModel == null || spaces == null || systemPlantRoom == null || airSystem == null)
            {
                return null;
            }

            SystemEnergyCentre systemEnergyCentre = analyticalModel.GetValue<SystemEnergyCentre>(AnalyticalModelParameter.SystemEnergyCentre);
            if(systemEnergyCentre == null)
            {
                return null;
            }

            SystemPlantRoom systemPlantRoom_Destination = systemEnergyCentre.GetSystemPlantRooms()?.FirstOrDefault();

            AirSystem airSystem_Source = systemPlantRoom.GetSystems<AirSystem>().Find(x => x.Name == airSystem.Name);
            if (airSystem_Source == null)
            {
                return null;
            }

            AirSystem result = systemPlantRoom_Destination.GetSystems<AirSystem>().Find(x => x.Name == airSystem.Name);
            if (result == null)
            {
                result = Copy(systemPlantRoom, systemPlantRoom_Destination, airSystem_Source);
            }

            List<SystemSpace> systemSpaces = systemPlantRoom_Destination.GetRelatedObjects<SystemSpace>(result);

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
    }
}