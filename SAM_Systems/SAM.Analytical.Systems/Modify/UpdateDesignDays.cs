using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static void UpdateDesignDays(this SystemEnergyCentre systemEnergyCentre, AnalyticalModel analyticalModel, bool includeAnnualDesignCondition = true)
        {
            if(analyticalModel is null || systemEnergyCentre is null)
            {
                return;
            }

            List<DesignDay> designDays_Heating = new List<DesignDay>();

            if (analyticalModel.TryGetValue(Analytical.AnalyticalModelParameter.HeatingDesignDays, out SAMCollection<DesignDay> heatingDesignDays) && heatingDesignDays != null)
            {
                designDays_Heating.AddRange(heatingDesignDays);
            }

            List<DesignDay> designDays_Cooling = new List<DesignDay>();

            if (analyticalModel.TryGetValue(Analytical.AnalyticalModelParameter.CoolingDesignDays, out SAMCollection<DesignDay> coolingDesignDays) && coolingDesignDays != null)
            {
                designDays_Cooling.AddRange(coolingDesignDays);
            }

            UpdateDesignDays(systemEnergyCentre, analyticalModel.AdjacencyCluster, designDays_Heating, designDays_Cooling, includeAnnualDesignCondition);
        }

        public static void UpdateDesignDays(this SystemEnergyCentre systemEnergyCentre, AdjacencyCluster adjacencyCluster, IEnumerable<DesignDay> designDays_Heating, IEnumerable<DesignDay> designDays_Cooling, bool includeAnnualDesignCondition = true)
        {
            if (systemEnergyCentre is null)
            {
                return;
            }

            List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre.GetSystemPlantRooms();
            if(systemPlantRooms is null || !systemPlantRooms.Any())
            {
                return;
            }

            HashSet<string> names_Cooling = new HashSet<string>();
            foreach(DesignDay designDay in designDays_Cooling)
            {
                if(designDay?.Name is string name)
                {
                    names_Cooling.Add(name);
                }
            }

            if(includeAnnualDesignCondition)
            {
                names_Cooling.Add("Annual Design Condition");
            }

            HashSet<string> names_Heating = new HashSet<string>();
            foreach (DesignDay designDay in designDays_Heating)
            {
                if (designDay?.Name is string name)
                {
                    names_Heating.Add(name);
                }
            }

            if (includeAnnualDesignCondition)
            {
                names_Heating.Add("Annual Design Condition");
            }

            Func<ISizableValue, IEnumerable<string>, ISizableValue> update_SizableValue = new Func<ISizableValue, IEnumerable<string>, ISizableValue>((sizableValue, names) => 
            {
                if (sizableValue is DesignConditionSizableValue designConditionSizableValue)
                {
                    designConditionSizableValue.DesignConditionNames = names == null ? new HashSet<string>() : new HashSet<string>(names);
                }

                if (sizableValue is DesignConditionSizedFlowValue designConditionSizedFlowValue)
                {
                    designConditionSizedFlowValue.DesignConditionNames = names == null ? new HashSet<string>() : new HashSet<string>(names);
                }

                return sizableValue;
            });

            Func<SizedFlowValue, IEnumerable<string>, SizedFlowValue> update_SizedFlowValue = new Func<SizedFlowValue, IEnumerable<string>, SizedFlowValue>((sizableValue, names) =>
            {
                if (sizableValue is DesignConditionSizedFlowValue designConditionSizedFlowValue)
                {
                    designConditionSizedFlowValue.DesignConditionNames = names == null ? new HashSet<string>() : new HashSet<string>(names);
                }

                return sizableValue;
            });

            foreach (SystemPlantRoom systemPlantRoom in systemPlantRooms)
            {
                List<ISystemSpaceComponent> systemSpaceComponents = systemPlantRoom.GetSystemComponents<ISystemSpaceComponent>();
                if(systemSpaceComponents != null)
                {
                    foreach(ISystemSpaceComponent systemSpaceComponent in systemSpaceComponents)
                    {
                        SystemSpace systemSpace = systemPlantRoom.GetRelatedObjects<SystemSpace>(systemSpaceComponent)?.FirstOrDefault();
                        if(systemSpace is null)
                        {
                            continue;
                        }

                        Space space = adjacencyCluster.GetObject<Space>(x => x?.Name == systemSpace.Name);
                        if(space is null)
                        {
                            continue;
                        }

                        List<MechanicalSystem> mechanicalSystems = adjacencyCluster.GetRelatedObjects<MechanicalSystem>(space);
                        if(mechanicalSystems is null || mechanicalSystems.Count == 0)
                        {
                            continue;
                        }

                        Analytical.CoolingSystem coolingSystem = mechanicalSystems.Find(x => x is Analytical.CoolingSystem) as Analytical.CoolingSystem;
                        Analytical.HeatingSystem heatingSystem = mechanicalSystems.Find(x => x is Analytical.HeatingSystem) as Analytical.HeatingSystem;

                        if (systemSpaceComponent is SystemRadiator systemRadiator)
                        {
                            systemRadiator.Duty = update_SizableValue.Invoke(systemRadiator.Duty, names_Heating);
                        }

                        if (systemSpaceComponent is SystemChilledBeam systemChilledBeam)
                        {
                            List<string> names_All = new List<string>();
                            if (heatingSystem?.Type?.Name is string name_Heating && (name_Heating == "CHB" || name_Heating == "RP" || name_Heating == "UFC"))
                            {
                                systemChilledBeam.HeatingDuty = update_SizableValue.Invoke(systemChilledBeam.HeatingDuty, names_Heating);
                                names_All.AddRange(names_Heating);
                            }

                            if (coolingSystem?.Type?.Name is string name_Cooling && (name_Cooling == "CHB" || name_Cooling == "RP" || name_Cooling == "UFC"))
                            {
                                systemChilledBeam.CoolingDuty = update_SizableValue.Invoke(systemChilledBeam.CoolingDuty, names_Cooling);
                                names_All.AddRange(names_Cooling);
                            }

                            systemChilledBeam.DesignFlowRate = update_SizedFlowValue.Invoke(systemChilledBeam.DesignFlowRate, names_All);
                        }

                        if (systemSpaceComponent is SystemFanCoilUnit systemFanCoilUnit)
                        {
                            List<string> names_All = new List<string>();
                            if (heatingSystem?.Type?.Name is string name_Heating && (name_Heating == "FCU" || name_Heating == "CHB"))
                            {
                                systemFanCoilUnit.HeatingDuty = update_SizableValue.Invoke(systemFanCoilUnit.HeatingDuty, names_Heating);
                                names_All.AddRange(names_Heating);
                            }

                            if (coolingSystem?.Type?.Name is string name_Cooling && (name_Cooling == "FCU" || name_Cooling == "CHB"))
                            {
                                systemFanCoilUnit.CoolingDuty = update_SizableValue.Invoke(systemFanCoilUnit.CoolingDuty, names_Cooling);
                                names_All.AddRange(names_Cooling);
                            }

                            systemFanCoilUnit.DesignFlowRate = update_SizedFlowValue.Invoke(systemFanCoilUnit.DesignFlowRate, names_All);
                        }

                        if (systemSpaceComponent is SystemDXCoilUnit systemDXCoilUnit)
                        {
                            List<string> names_All = new List<string>();
                            if (heatingSystem?.Type?.Name is string name_Heating && name_Heating == "VRV")
                            {
                                systemDXCoilUnit.HeatingDuty = update_SizableValue.Invoke(systemDXCoilUnit.HeatingDuty, names_Heating);
                                names_All.AddRange(names_Heating);
                            }

                            if (coolingSystem?.Type?.Name is string name_Cooling && name_Cooling == "VRV")
                            {
                                systemDXCoilUnit.CoolingDuty = update_SizableValue.Invoke(systemDXCoilUnit.CoolingDuty, names_Cooling);
                                names_All.AddRange(names_Cooling);
                            }

                            systemDXCoilUnit.DesignFlowRate = update_SizedFlowValue.Invoke(systemDXCoilUnit.DesignFlowRate, names_All);
                        }

                        systemPlantRoom.Add(systemSpaceComponent);
                    }
                }

                systemEnergyCentre.Add(systemPlantRoom);
            }
        }
    }
}