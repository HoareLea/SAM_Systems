// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using SAM.Core.Systems;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static List<string> UpdateSpaceAirflows(this SystemEnergyCentre systemEnergyCentre, Dictionary<string, Tuple<double?, double?>> airflows)
        {
            if(systemEnergyCentre is null)
            {
                return null;
            }

            List<string> result = new List<string>();

            if (airflows is null || airflows.Count == 0)
            {
                return result;
            }

            List<SystemPlantRoom> systemPlantRooms = systemEnergyCentre.GetSystemPlantRooms();
            if(systemPlantRooms != null && systemPlantRooms.Count != 0)
            {
                foreach (SystemPlantRoom systemPlantRoom in systemPlantRooms)
                {
                    bool updated = false;
                    foreach(KeyValuePair<string, Tuple<double?, double?>> keyValuePair in airflows)
                    {
                        SystemSpace systemSpace = systemPlantRoom.Find<SystemSpace>(x => keyValuePair.Key == x.Name);
                        if(systemSpace is null)
                        {
                            continue;
                        }

                        Tuple<double?, double?> tuple = keyValuePair.Value;
                        double? airFlow = tuple.Item1;
                        double? freshAirFlow = tuple.Item2;

                        bool changed = false;

                        if (airFlow != null && airFlow.HasValue)
                        {
                            DesignConditionSizedFlowValue designConditionSizedFlowValue = systemSpace.FlowRate;
                            if(designConditionSizedFlowValue != null)
                            {
                                designConditionSizedFlowValue.SizingType = SizingType.None;

                                if (!double.IsNaN(airFlow.Value))
                                {
                                    designConditionSizedFlowValue.SizingType = SizingType.Value;
                                    designConditionSizedFlowValue.Value = airFlow.Value;
                                }
                                else // if the value set 2 and SizingType to None 
                                {
                                    designConditionSizedFlowValue.SizingType = SizingType.None;
                                    designConditionSizedFlowValue.Value = 0;
                                }

                                systemSpace.FlowRate = designConditionSizedFlowValue;
                                changed = true;
                            }
                        }

                        if (freshAirFlow != null && freshAirFlow.HasValue)
                        {
                            DesignConditionSizedFlowValue designConditionSizedFlowValue = systemSpace.FreshAir;
                            if(designConditionSizedFlowValue != null)
                            {
                                designConditionSizedFlowValue.SizingType = SizingType.None;

                                if (!double.IsNaN(freshAirFlow.Value))
                                {
                                    designConditionSizedFlowValue.SizingType = SizingType.Value;
                                    designConditionSizedFlowValue.Value = freshAirFlow.Value;
                                }
                                else
                                {
                                    designConditionSizedFlowValue.SizingType = SizingType.None;
                                    designConditionSizedFlowValue.Value = 0;
                                }

                                systemSpace.FreshAir = designConditionSizedFlowValue;
                                changed = true;
                            }
                        }

                        if (changed)
                        {
                            updated = true;

                            systemPlantRoom.Add(systemSpace);

                            result.Add(keyValuePair.Key);
                        }
                    }

                    if(updated)
                    {
                        systemEnergyCentre.Add(systemPlantRoom);
                    }
                }
            }

            return result;
        }
    }
}