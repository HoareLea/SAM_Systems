// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using SAM.Analytical.Enums;
using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static SystemEnergyCentre SystemEnergyCentre(this AnalyticalModel analyticalModel, List<SystemEnergyCentre> systemEnergyCentres = null)
        {
            return SystemEnergyCentre(analyticalModel, out HashSet<string> unavailableSystemTypeNames, systemEnergyCentres);
        }

        public static SystemEnergyCentre SystemEnergyCentre(this AnalyticalModel analyticalModel, out HashSet<string> unavailableSystemTypeNames, List<SystemEnergyCentre> systemEnergyCentres = null)
        {
            unavailableSystemTypeNames = null;

            if (analyticalModel == null)
            {
                return null;
            }

            List<Space> spaces = analyticalModel.GetSpaces();
            if (spaces == null)
            {
                return null;
            }

            List<SystemEnergyCentre> systemEnergyCentres_Default = systemEnergyCentres;
            if (systemEnergyCentres_Default is null || systemEnergyCentres_Default.Count == 0)
            {
                systemEnergyCentres_Default = Query.DefaultSystemEnergyCentres();
            }

            if (systemEnergyCentres_Default == null || systemEnergyCentres_Default.Count == 0)
            {
                return null;
            }

            List<Tuple<Space, SystemTemplate>> tuples_AnalyticalModel = new List<Tuple<Space, SystemTemplate>>();

            foreach (Space space in spaces)
            {
                InternalCondition internalCondition = space?.InternalCondition;
                if (internalCondition == null || !internalCondition.TryGetValue(InternalConditionParameter.VentilationSystemTypeName, out string ventilationSystemTypeName) || string.IsNullOrWhiteSpace(ventilationSystemTypeName))
                {
                    ventilationSystemTypeName = null;
                    continue;
                }

                if (internalCondition == null || !internalCondition.TryGetValue(InternalConditionParameter.HeatingSystemTypeName, out string heatingSystemTypeName) || string.IsNullOrWhiteSpace(heatingSystemTypeName))
                {
                    heatingSystemTypeName = null;
                }

                if (internalCondition == null || !internalCondition.TryGetValue(InternalConditionParameter.CoolingSystemTypeName, out string coolingSystemTypeName) || string.IsNullOrWhiteSpace(coolingSystemTypeName))
                {
                    coolingSystemTypeName = null;
                }

                SystemTemplate systemTemplate = new SystemTemplate()
                {
                    Ventilation = ventilationSystemTypeName,
                    Heating = heatingSystemTypeName,
                    Cooling = coolingSystemTypeName
                };

                tuples_AnalyticalModel.Add(new Tuple<Space, SystemTemplate>(space, systemTemplate));
            }

            SystemEnergyCentre result = new SystemEnergyCentre(analyticalModel.Name);

            while (tuples_AnalyticalModel.Count > 0)
            {
                SystemPlantRoom systemPlantRoom_Template = null;

                Tuple<Space, SystemTemplate> tuple = tuples_AnalyticalModel[0];

                List<Tuple<Space, SystemTemplate>> tuples_Temp = tuples_AnalyticalModel.FindAll(x => x.Item2.ToString() == tuple.Item2.ToString());
                tuples_AnalyticalModel.RemoveAll(x => tuples_Temp.Contains(x));

                SystemTemplate systemTemplate = tuple.Item2;

                foreach (SystemEnergyCentre systemEnergyCentre_Default in systemEnergyCentres_Default)
                {
                    SystemTemplate systemTemplate_Default = systemEnergyCentre_Default.GetValue<SystemTemplate>(SystemEnergyCentreParameter.SystemTemplate);
                    if (systemTemplate_Default is null)
                    {
                        continue;
                    }

                    if (!(systemTemplate_Default.Ventilation == systemTemplate.Ventilation || (systemTemplate_Default.IsUnventilated() && systemTemplate.IsUnventilated())))
                    {
                        continue;
                    }

                    if (!(systemTemplate_Default.Heating == systemTemplate.Heating || (systemTemplate_Default.IsUnheated() && systemTemplate.IsUnheated())))
                    {
                        continue;
                    }

                    if (!(systemTemplate_Default.Cooling == systemTemplate.Cooling || (systemTemplate_Default.IsUncooled() && systemTemplate.IsUncooled())))
                    {
                        continue;
                    }

                    systemPlantRoom_Template = systemEnergyCentre_Default.GetSystemPlantRooms()?.FirstOrDefault();
                    if (systemPlantRoom_Template != null)
                    {
                        break;
                    }
                }

                if (systemPlantRoom_Template is null)
                {
                    List<SystemPlantRoom> systemPlantRooms = systemEnergyCentres_Default.DefaultSystemPlantRooms(tuple.Item2.Ventilation);

                    systemPlantRoom_Template = systemPlantRooms?.FirstOrDefault();
                }

                if (systemPlantRoom_Template is null)
                {
                    if (unavailableSystemTypeNames == null)
                    {
                        unavailableSystemTypeNames = new HashSet<string>();
                    }

                    unavailableSystemTypeNames.Add(tuple.Item2.ToString());
                    continue;
                }

                //Copy properties
                SystemEnergyCentre systemEnergyCentre = systemEnergyCentres_Default.Find(x => x.GetSystemPlantRoom(new ObjectReference(systemPlantRoom_Template)) != null);
                if (systemEnergyCentre != null)
                {
                    //Copy Analytical Systems Properties
                    AnalyticalSystemsProperties analyticalSystemsProperties_Source = systemEnergyCentre.GetValue<AnalyticalSystemsProperties>(SystemEnergyCentreParameter.AnalyticalSystemsProperties);
                    if (analyticalSystemsProperties_Source != null)
                    {
                        AnalyticalSystemsProperties analyticalSystemsProperties_Destination = result.GetValue<AnalyticalSystemsProperties>(SystemEnergyCentreParameter.AnalyticalSystemsProperties);
                        if (analyticalSystemsProperties_Destination == null)
                        {
                            analyticalSystemsProperties_Destination = new AnalyticalSystemsProperties(analyticalSystemsProperties_Source);
                        }
                        else
                        {
                            List<ISchedule> schedules = analyticalSystemsProperties_Source.Schedules;
                            if (schedules != null)
                            {
                                foreach (ISchedule schedule in schedules)
                                {
                                    analyticalSystemsProperties_Destination.Add(schedule);
                                }
                            }

                            List<FluidType> fluidTypes = analyticalSystemsProperties_Source.FluidTypes;
                            if (fluidTypes != null)
                            {
                                foreach (FluidType fluidType in fluidTypes)
                                {
                                    analyticalSystemsProperties_Destination.Add(fluidType);
                                }
                            }

                            List<DesignCondition> designConditions = analyticalSystemsProperties_Source.DesignConditions;
                            if (designConditions != null)
                            {
                                foreach (DesignCondition designCondition in designConditions)
                                {
                                    analyticalSystemsProperties_Destination.Add(designCondition);
                                }
                            }
                        }

                        result.SetValue(SystemEnergyCentreParameter.AnalyticalSystemsProperties, analyticalSystemsProperties_Destination);
                    }

                    //Copy SystemEnergySources
                    List<SystemEnergySource> systemEnergySources = systemEnergyCentre.GetSystemEnergySources();
                    if (systemEnergySources != null)
                    {
                        foreach (SystemEnergySource systemEnergySource in systemEnergySources)
                        {
                            result.Add(systemEnergySource);
                        }
                    }
                }

                List<Tuple<VentilationSystem, List<Space>>> tuples_System = new List<Tuple<VentilationSystem, List<Space>>>();
                List<VentilationSystem> ventilationSystems = analyticalModel.GetMechanicalSystems<VentilationSystem>();
                if (ventilationSystems == null || ventilationSystems.Count == 0)
                {
                    tuples_System.Add(new Tuple<VentilationSystem, List<Space>>(null, tuples_Temp.ConvertAll(x => x.Item1)));
                }
                else
                {
                    List<Space> spaces_Temp = tuples_Temp.ConvertAll(x => x.Item1);

                    foreach (VentilationSystem ventilationSystem in ventilationSystems)
                    {
                        List<Guid> guids = analyticalModel.GetRelatedObjects<Space>(ventilationSystem)?.ConvertAll(x => x.Guid);
                        if (guids == null || guids.Count == 0)
                        {
                            continue;
                        }

                        Core.Query.Filter(spaces_Temp, out List<Space> spaces_In, out List<Space> spaces_Out, x => x?.Guid != null && guids.Contains(x.Guid));
                        if(spaces_In != null && spaces_In.Count != 0)
                        {
                            tuples_System.Add(new Tuple<VentilationSystem, List<Space>>(ventilationSystem, spaces_In));
                        }
                        
                        spaces_Temp = spaces_Out;
                    }

                    if (spaces_Temp != null && spaces_Temp.Count != 0)
                    {
                        tuples_System.Add(new Tuple<VentilationSystem, List<Space>>(null, spaces_Temp));
                    }
                }

                foreach (Tuple<VentilationSystem, List<Space>> tuple_System in tuples_System)
                {
                    if(tuple_System.Item2 is null ||tuple_System.Item2.Count == 0)
                    {
                        continue;
                    }

                    SystemPlantRoom systemPlantRoom = systemPlantRoom_Template.Duplicate();
                    // SystemPlantRoom systemPlantRoom = systemPlantRoom_Template.Clone();
                    // systemPlantRoom = new SystemPlantRoom(Guid.NewGuid(), systemPlantRoom);

                    if (result.GetSystemPlantRoom(systemPlantRoom.Name) != null)
                    {
                        int index = 2;
                        string name_SystemPlantRoom = string.Format("{0} {1}", systemPlantRoom.Name, index);
                        while (result.GetSystemPlantRoom(name_SystemPlantRoom) != null)
                        {
                            index++;
                            name_SystemPlantRoom = string.Format("{0} {1}", systemPlantRoom.Name, index);
                        }

                        systemPlantRoom.Name = name_SystemPlantRoom;
                    }

                    List<SystemSpace> systemSpaces = systemPlantRoom.GetSystemComponents<SystemSpace>();
                    if (systemSpaces == null || systemSpaces.Count == 0)
                    {
                        result.Add(systemPlantRoom);
                        continue;
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

                    //2026.03.26 NEW matching system for PartFSpaceData.PartFVentilationType

                    Dictionary<string, List<Space>> dictionary_Space = new Dictionary<string, List<Space>>();
                    foreach (Space space in tuple_System.Item2)
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

                    //2026.03.26 Old approach below

                    //bool single = tuples.ConvertAll(x => x.Item1).FindAll(x => !string.IsNullOrEmpty(x)).Distinct().Count() <= 1;
                    //if(single)
                    //{
                    //    SystemSpace systemSpace = tuples.First().Item2;

                    //    foreach (Space space in tuples_Temp.ConvertAll(x => x.Item1))
                    //    {
                    //        systemPlantRoom.Duplicate(systemSpace, space);
                    //    }
                    //}
                    //else
                    //{
                    //    throw new NotImplementedException();
                    //}

                    tuples.ForEach(x => systemPlantRoom.Remove(x.Item2));

                    result.Add(systemPlantRoom);
                }
            }

            return result;

        }
    }
}