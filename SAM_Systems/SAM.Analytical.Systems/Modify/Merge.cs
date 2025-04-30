using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
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

                    SystemPlantRoom systemPlantRoom_Temp = systemPlantRoom.Duplicate();

                    systemEnergyCentre.Add(systemPlantRoom_Temp);
                }
            }
            else if (systemPlantRoomCount == 0)
            {
                List<Tuple<SystemEnergyCentre, SystemPlantRoom, List<AirSystem>>> tuples = new List<Tuple<SystemEnergyCentre, SystemPlantRoom, List<AirSystem>>>();
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

                    if(systemPlantRoom_Source == null)
                    {
                        continue;
                    }

                    systemEnergyCentres_Source.Add(systemEnergyCentre_Source);

                    Tuple<SystemEnergyCentre, SystemPlantRoom, List<AirSystem>> tuple = tuples.Find(x => x.Item1.Guid == systemEnergyCentre_Source.Guid && x.Item2.Guid == systemPlantRoom_Source.Guid);
                    if(tuple == null)
                    {
                        tuple = new Tuple<SystemEnergyCentre, SystemPlantRoom, List<AirSystem>>(systemEnergyCentre_Source, systemPlantRoom_Source, new List<AirSystem>());
                        tuples.Add(tuple);
                    }

                    tuple.Item3.Add(airSystem);
                }

                foreach (Tuple<SystemEnergyCentre, SystemPlantRoom, List<AirSystem>> tuple in tuples)
                {
                    SystemEnergyCentre systemEnergyCentre_Temp = tuple.Item1;
                    SystemPlantRoom systemPlantRoom_Temp = new SystemPlantRoom(tuple.Item2);

                    List<AirSystem> airSystems_Temp = systemPlantRoom_Temp.GetSystemObjects<AirSystem>();
                    for (int i = airSystems_Temp.Count - 1; i >= 0; i--)
                    {
                        if (tuple.Item3.Find(x => x.Guid == airSystems_Temp[i].Guid) != null)
                        {
                            airSystems_Temp.RemoveAt(i);
                        }
                    }

                    foreach(AirSystem airSystem_Temp in airSystems_Temp)
                    {
                        systemPlantRoom_Temp.Remove(airSystem_Temp);
                    }

                    airSystems_Temp = systemPlantRoom_Temp.GetSystemObjects<AirSystem>();
                    foreach(AirSystem airSystem_Temp in airSystems_Temp)
                    {
                        int count = tuple.Item3.FindAll(x => x.Guid == airSystem_Temp.Guid).Count();
                        for (int i = 1; i < count; i++)
                        {
                            systemPlantRoom_Temp.Duplicate(airSystem_Temp);
                        }
                    }

                    systemPlantRoom_Temp = systemPlantRoom_Temp.Duplicate();
                    systemEnergyCentre.Add(systemPlantRoom_Temp);
                }
            }
            else
            {
                //tuple.Item1 -> Destination SystemPlantRoom
                //tuple.Item2 -> Source SystemEnergyCentre
                //tuple.Item3 -> Source SystemPlantRoom
                //tuple.Item4 -> Source AirSystem
                List<Tuple<SystemPlantRoom, SystemEnergyCentre, SystemPlantRoom, AirSystem>> tuples = new List<Tuple<SystemPlantRoom, SystemEnergyCentre, SystemPlantRoom, AirSystem>>();

                for (int i = 0; i < airSystems.Count(); i++)
                {
                    AirSystem airSystem_Source = airSystems.ElementAt(i);
                    if(airSystem_Source == null)
                    {
                        continue;
                    }

                    SystemPlantRoom systemPlantRoom_Destination = systemPlantRooms.ElementAt(i);
                    if(systemPlantRoom_Destination == null)
                    {
                        continue;
                    }

                    SystemPlantRoom systemPlantRoom_Source = null;
                    SystemEnergyCentre systemEnergyCentre_Source = null;

                    foreach (SystemEnergyCentre systemEnergyCentre_Temp in systemEnergyCentres)
                    {
                        foreach (SystemPlantRoom systemPlantRoom_Temp in systemEnergyCentre_Temp.GetSystemPlantRooms())
                        {
                            if (systemPlantRoom_Temp.GetSystemObject<AirSystem>(new ObjectReference(airSystem_Source)) != null)
                            {
                                systemPlantRoom_Source = systemPlantRoom_Temp;
                                systemEnergyCentre_Source = systemEnergyCentre_Temp;
                                break;
                            }
                        }

                        if (systemPlantRoom_Source != null)
                        {
                            break;
                        }
                    }

                    if (systemPlantRoom_Source == null)
                    {
                        continue;
                    }

                    if(systemEnergyCentres_Source.Find(x => x.Guid == systemEnergyCentre_Source.Guid) == null)
                    {
                        systemEnergyCentres_Source.Add(systemEnergyCentre_Source);
                    }

                    tuples.Add(new Tuple<SystemPlantRoom, SystemEnergyCentre, SystemPlantRoom, AirSystem>(systemPlantRoom_Destination, systemEnergyCentre_Source, systemPlantRoom_Source, airSystem_Source));
                }

                while(tuples.Count > 0)
                {
                    Tuple<SystemPlantRoom, SystemEnergyCentre, SystemPlantRoom, AirSystem> tuple = tuples[0];

                    List<Tuple<SystemPlantRoom, SystemEnergyCentre, SystemPlantRoom, AirSystem>> tuples_Temp = tuples.FindAll(x => x.Item1.Guid == tuple.Item1.Guid);

                    tuples_Temp.ForEach(x => tuples.Remove(x));

                    SystemPlantRoom systemPlantRoom_Destination = tuple.Item1;

                    HashSet<Guid> guids = new HashSet<Guid>();
                    foreach(Tuple<SystemPlantRoom, SystemEnergyCentre, SystemPlantRoom, AirSystem> tuple_Temp in tuples_Temp)
                    {
                        SystemPlantRoom systemPlantRoom_Source = tuple_Temp.Item3;
                        AirSystem airSystem_Source = tuple_Temp.Item4;

                        airSystem_Source = systemPlantRoom_Source.Duplicate(airSystem_Source);
                        guids.Add(airSystem_Source.Guid);

                        systemPlantRoom_Destination.CopyFrom(systemPlantRoom_Source, airSystem_Source.Guid);
                    }

                    List<AirSystem> airSystems_Temp = systemPlantRoom_Destination.GetSystemObjects<AirSystem>();
                    if(airSystems_Temp != null)
                    {
                        foreach(AirSystem airSystem_Temp in airSystems_Temp)
                        {
                            if(guids.Contains(airSystem_Temp.Guid))
                            {
                                continue;
                            }

                            systemPlantRoom_Destination.Remove(airSystem_Temp, true);
                        }
                    }

                    systemEnergyCentre.Add(systemPlantRoom_Destination);
                }
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
                                analyticalSystemsProperties_Destination.Add(schedule_Source.Clone());
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
                                analyticalSystemsProperties_Destination.Add(designCondition_Source.Clone());
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
                                analyticalSystemsProperties_Destination.Add(fluidType_Source.Clone());
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