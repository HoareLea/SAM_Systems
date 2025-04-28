using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static bool RenameAirSystemGroups(this SystemEnergyCentre systemEnergyCentre)
        {
            if (systemEnergyCentre == null)
            {
                return false;
            }

            bool result = false;

            List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre.GetSystemPlantRooms();
            if (systemPlantRooms != null)
            {
                foreach (SystemPlantRoom systemPlantRoom in systemPlantRooms)
                {
                    List<AirSystem> airSystems = systemPlantRoom.GetSystems<AirSystem>();
                    if (airSystems != null)
                    {
                        foreach (AirSystem airSystem in airSystems)
                        {
                            List<AirSystemGroup> airSystemGroups = systemPlantRoom.GetRelatedObjects<AirSystemGroup>(airSystem);
                            if (airSystemGroups != null)
                            {
                                for (int i = 0; i < airSystemGroups.Count; i++)
                                {
                                    string sufix = string.Empty;

                                    if (i > 0)
                                    {
                                        sufix = string.Format("_{0}", i + 1);
                                    }

                                    airSystemGroups[i].Name = string.Format("{0}{1}", airSystem.Name == null ? string.Empty : airSystem.Name, sufix);
                                    systemPlantRoom.Add(airSystemGroups[i]);
                                    result = true;
                                }
                            }
                        }
                    }

                    systemEnergyCentre.Add(systemPlantRoom);
                }
            }

            return result;

        }
    }
}