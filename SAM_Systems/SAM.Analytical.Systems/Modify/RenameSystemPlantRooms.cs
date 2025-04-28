using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static bool RenameSystemPlantRooms(this SystemEnergyCentre systemEnergyCentre)
        {
            if (systemEnergyCentre == null)
            {
                return false;
            }

            bool result = false;

            List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre.GetSystemPlantRooms();
            if (systemPlantRooms != null)
            {
                while (systemPlantRooms.Count > 0)
                {
                    List<SystemPlantRoom> systemPlantRooms_Temp = systemPlantRooms.FindAll(x => x.Name == systemPlantRooms[0].Name);
                    systemPlantRooms_Temp.ForEach(x => systemPlantRooms.Remove(x));
                    if (systemPlantRooms_Temp.Count > 1)
                    {
                        for (int i = 1; i < systemPlantRooms_Temp.Count; i++)
                        {
                            systemPlantRooms_Temp[i].Name = string.Format("{0}_{1}", systemPlantRooms_Temp[0].Name, i + 1);
                            systemEnergyCentre.Add(systemPlantRooms_Temp[i]);
                        }
                    }
                }

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