using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static List<SystemPlantRoom> DefaultSystemPlantRooms(this IEnumerable<SystemEnergyCentre> systemEnergyCentres, string name)
        {
            if(systemEnergyCentres == null || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            List<SystemPlantRoom> result = new List<SystemPlantRoom>();
            foreach(SystemEnergyCentre systemEnergyCentre in systemEnergyCentres)
            {
                if (systemEnergyCentre == null)
                {
                    continue;
                }

                List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre.GetSystemPlantRooms();
                if(systemPlantRooms == null)
                {
                    continue;
                }

                foreach(SystemPlantRoom systemPlantRoom in systemPlantRooms)
                {
                    if(systemPlantRoom == null)
                    {
                        continue;
                    }

                    List<AirSystem> airSystems = systemPlantRoom.GetSystems<AirSystem>();
                    if(airSystems == null)
                    {
                        continue;
                    }

                    foreach(AirSystem airSystem in airSystems)
                    {
                        string airSystemName = airSystem?.Name;
                        if(string.IsNullOrWhiteSpace(airSystemName))
                        {
                            continue; 
                        }

                        if(airSystemName.StartsWith(name))
                        {
                            result.Add(systemPlantRoom);
                            break;
                        }

                    }
                }
            }

            return result;
        }
    }
}
