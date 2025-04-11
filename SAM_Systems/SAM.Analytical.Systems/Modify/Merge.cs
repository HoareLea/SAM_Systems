using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

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

                if (!systemEnergyCentre_Destination.TryGetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, out AnalyticalSystemsProperties analyticalSystemsProperties_Destination) || analyticalSystemsProperties_Destination == null)
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

            if (airSystem == null)
            {
                if (systemPlantRoom == null)
                {
                    List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre_Source?.GetSystemPlantRooms();
                    if (systemPlantRooms != null)
                    {
                        foreach (SystemPlantRoom systemPlantRoom_Temp in systemPlantRooms)
                        {
                            systemEnergyCentre_Destination.Add(systemPlantRoom_Temp);
                        }
                    }
                }
                else
                {
                    SystemPlantRoom systemPlantRoom_Temp = systemEnergyCentre_Source?.GetSystemPlantRooms()?.Find(x => x.Guid == systemPlantRoom.Guid);
                    if (systemPlantRoom_Temp != null)
                    {
                        systemEnergyCentre_Destination.Add(systemPlantRoom_Temp);
                    }
                }
            }
            else
            {
                AirSystem airSystem_Source = null;
                SystemPlantRoom systemPlantRoom_Source = null;

                List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre_Source?.GetSystemPlantRooms();
                if (systemPlantRooms != null)
                {
                    foreach (SystemPlantRoom systemPlantRoom_Temp in systemPlantRooms)
                    {
                        AirSystem airSystem_Temp = systemPlantRoom_Temp.GetSystem<AirSystem>(x => x.Guid == airSystem.Guid);
                        if (airSystem_Temp == null)
                        {
                            continue;
                        }
                        airSystem_Source = airSystem_Temp;
                        systemPlantRoom_Source = systemPlantRoom_Temp;
                        break;
                    }
                }

                if (airSystem_Source == null || systemPlantRoom_Source == null)
                {
                    return false;
                }

                if (systemPlantRoom != null)
                {
                    SystemPlantRoom systemPlantRoom_Temp = systemEnergyCentre_Destination?.GetSystemPlantRooms()?.Find(x => x.Guid == systemPlantRoom.Guid);
                    if (systemPlantRoom_Temp != null)
                    {
                        List<ISystemJSAMObject> systemJSAMObjects = systemPlantRoom_Source.GetRelatedObjects<ISystemJSAMObject>(airSystem_Source);
                        if (systemJSAMObjects != null)
                        {
                            foreach (ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
                            {
                                systemPlantRoom_Temp.Add(systemJSAMObject as dynamic);
                            }
                        }

                        systemPlantRoom_Temp.Add(airSystem_Source);

                        systemPlantRoom_Temp.Connect(airSystem_Source, systemJSAMObjects.FindAll(x => x is ISystemComponent).Cast<ISystemComponent>());

                        foreach (ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
                        {
                            List<ISystemJSAMObject> systemJSAMObjects_Related = systemPlantRoom_Source.GetRelatedObjects<ISystemJSAMObject>(systemJSAMObject);
                            if (systemJSAMObjects_Related != null)
                            {
                                foreach (ISystemJSAMObject systemJSAMObject_Related in systemJSAMObjects_Related)
                                {

                                }
                            }
                        }

                        systemEnergyCentre_Destination.Add(systemPlantRoom_Temp);
                    }
                }
                else
                {





                }
            }

            return true;
        }

        public static bool Merge(this SystemEnergyCentre systemEnergyCentre, IEnumerable<SystemEnergyCentre> systemEnergyCentres, IEnumerable<AirSystem> airSystems = null, IEnumerable<SystemPlantRoom> systemPlantRooms = null)
        {
            if (systemEnergyCentre == null || systemEnergyCentres == null || systemEnergyCentres.Count() == 0)
            {
                return false;
            }

            int airSystemCount = airSystems == null ? 0 : airSystems.Count();
            int systemPlantRoomCount = systemPlantRooms == null ? 0 : systemPlantRooms.Count();

            if (airSystemCount != 0 && systemPlantRoomCount != 0 && airSystemCount != systemPlantRoomCount)
            {
                return false;
            }

            List<SystemEnergyCentre> systemEnergyCentres_Source = new List<SystemEnergyCentre>();

            if (airSystemCount == 0 && systemPlantRoomCount == 0)
            {
                foreach (SystemEnergyCentre systemEnergyCentre_Temp in systemEnergyCentres)
                {
                    List<SystemPlantRoom> systemPlantRooms_SystemEnergyCentre = systemEnergyCentre_Temp.GetSystemPlantRooms();
                    if (systemPlantRooms_SystemEnergyCentre == null)
                    {
                        continue;
                    }

                    systemEnergyCentres_Source.Add(systemEnergyCentre_Temp);

                    foreach (SystemPlantRoom systemPlantRoom_SystemEnergyCentre in systemPlantRooms_SystemEnergyCentre)
                    {
                        if (systemPlantRooms_SystemEnergyCentre == null)
                        {
                            continue;
                        }

                        systemEnergyCentre.Add(systemPlantRoom_SystemEnergyCentre.Duplicate());
                    }
                }
            }
            else if (airSystemCount == 0)
            {
                foreach (SystemPlantRoom systemPlantRoom in systemPlantRooms)
                {
                    if(systemPlantRoom == null)
                    {
                        continue;
                    }

                    SystemEnergyCentre systemEnergyCentre_Source = systemEnergyCentres.ToList().Find(x => x.GetSystemPlantRoom(new ObjectReference(systemPlantRoom)) != null);
                    if(systemEnergyCentre_Source != null)
                    {
                        systemEnergyCentres_Source.Add(systemEnergyCentre_Source);

                    }

                    systemEnergyCentre.Add(systemPlantRoom);
                }
            }
            else if (systemPlantRoomCount == 0)
            {
                foreach(AirSystem airSystem in airSystems)
                {
                    SystemEnergyCentre systemEnergyCentre_Source = null;
                    SystemPlantRoom systemPlantRoom_Source = null;

                    foreach (SystemEnergyCentre systemEnergyCentre_Temp in systemEnergyCentres)
                    {
                        foreach (SystemPlantRoom systemPlantRoom_Temp in systemEnergyCentre_Temp.GetSystemPlantRooms())
                        {
                            if(systemPlantRoom_Temp.GetSystemObject<AirSystem>(new ObjectReference(airSystem)) != null)
                            {
                                systemEnergyCentre_Source = systemEnergyCentre_Temp;
                                systemPlantRoom_Source = systemPlantRoom_Temp;
                                break;
                            }
                        }

                        if(systemPlantRoom_Source != null)
                        {
                            break;
                        }
                    }

                    //TO BE UPDATED HERE
                }
            }
            else
            {

            }

            foreach (SystemEnergyCentre systemEnergyCentre_Source in systemEnergyCentres_Source)
            {
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

                        if (systemEnergyCentre.GetSystemEnergySource(systemEnergySource.Name) == null)
                        {
                            systemEnergyCentre.Add(systemEnergySource);
                        }
                    }
                }

                if (systemEnergyCentre_Source.TryGetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, out AnalyticalSystemsProperties analyticalSystemsProperties_Source) && analyticalSystemsProperties_Source != null)
                {

                    if (!systemEnergyCentre.TryGetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, out AnalyticalSystemsProperties analyticalSystemsProperties_Destination) || analyticalSystemsProperties_Destination == null)
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

                    systemEnergyCentre.SetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, analyticalSystemsProperties_Destination);
                }
            }

            return false;
        }
    }
}