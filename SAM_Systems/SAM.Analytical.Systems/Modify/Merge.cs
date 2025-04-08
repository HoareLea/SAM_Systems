using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static bool Merge(this SystemEnergyCentre systemEnergyCentre_Destination, SystemEnergyCentre systemEnergyCentre_Source, AirSystem airSystem = null, SystemPlantRoom systemPlantRoom = null)
        {
            if (systemEnergyCentre_Destination == null || systemEnergyCentre_Source == null)
            {
                return false;
            }

            List<SystemEnergySource> systemEnergySources = systemEnergyCentre_Source.GetSystemEnergySources();
            if (systemEnergySources != null)
            {
                foreach (SystemEnergySource systemEnergySource in systemEnergySources)
                {
                    string name = systemEnergySource?.Name;
                    if (name == null)
                    {
                        continue;
                    }

                    if (systemEnergyCentre_Destination.GetSystemEnergySource(systemEnergySource.Name) == null)
                    {
                        systemEnergyCentre_Destination.Add(systemEnergySource);
                    }
                }
            }

            if (systemEnergyCentre_Source.TryGetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, out AnalyticalSystemsProperties analyticalSystemsProperties_Source) && analyticalSystemsProperties_Source != null)
            {

                if (!systemEnergyCentre_Destination.TryGetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, out AnalyticalSystemsProperties analyticalSystemsProperties_Destination) && analyticalSystemsProperties_Destination != null)
                {
                    analyticalSystemsProperties_Destination = new AnalyticalSystemsProperties();
                }

                List<ISchedule> schedules_Source = analyticalSystemsProperties_Source.Schedules;
                if (schedules_Source != null)
                {
                    foreach (ISchedule schedule_Source in schedules_Source)
                    {
                        string name = schedule_Source?.Name;
                        if (name == null)
                        {
                            continue;
                        }

                        ISchedule schedule = analyticalSystemsProperties_Destination.FindSchedule(name);
                        if (schedule == null)
                        {
                            analyticalSystemsProperties_Destination.Add(schedule.Clone());
                        }
                    }
                }

                List<DesignCondition> designConditions_Source = analyticalSystemsProperties_Source.DesignConditions;
                if (designConditions_Source != null)
                {
                    foreach (DesignCondition designCondition_Source in designConditions_Source)
                    {
                        string name = designCondition_Source?.Name;
                        if (name == null)
                        {
                            continue;
                        }

                        DesignCondition designCondition = analyticalSystemsProperties_Destination.FindDesignCondition(name);
                        if (designCondition == null)
                        {
                            analyticalSystemsProperties_Destination.Add(designCondition.Clone());
                        }
                    }
                }

                List<FluidType> fluidTypes_Source = analyticalSystemsProperties_Source.FluidTypes;
                if (fluidTypes_Source != null)
                {
                    foreach (FluidType fluidType_Source in fluidTypes_Source)
                    {
                        string name = fluidType_Source?.Name;
                        if (name == null)
                        {
                            continue;
                        }

                        FluidType fluidType = analyticalSystemsProperties_Destination.FindFluidType(name);
                        if (fluidType == null)
                        {
                            analyticalSystemsProperties_Destination.Add(fluidType.Clone());
                        }
                    }
                }

                systemEnergyCentre_Source.SetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, systemEnergyCentre_Destination);
            }

            if (airSystem == null && systemPlantRoom == null)
            {
                List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre_Source?.GetSystemPlantRooms();
                if (systemPlantRooms != null)
                {
                    foreach (SystemPlantRoom systemPlantRoom_Temp in systemPlantRooms)
                    {
                        systemEnergyCentre_Destination.Add(systemPlantRoom_Temp);
                    }
                }

                return true;
            }

            if (airSystem == null && systemPlantRoom != null)
            {
                SystemPlantRoom systemPlantRoom_Temp = systemEnergyCentre_Source?.GetSystemPlantRooms()?.Find(x => x.Guid == systemPlantRoom.Guid);
                if(systemPlantRoom_Temp != null)
                {
                    systemEnergyCentre_Destination.Add(systemPlantRoom_Temp);
                }
            }

            return true;
        }
    }
}