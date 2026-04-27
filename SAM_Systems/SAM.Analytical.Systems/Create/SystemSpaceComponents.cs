using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static List<ISystemSpaceComponent> SystemSpaceComponents(this AdjacencyCluster adjacencyCluster, Space space, SystemPlantRoom systemPlantRoom)
        {
            bool radiator_Heating = false;
            bool chilledBeam_Heating = false;
            bool fanCoilUnit_Heating = false;
            bool dXCoilUnit_Heating = false;

            HeatingSystemType heatingSystemType = adjacencyCluster?.GetRelatedObjects<Analytical.HeatingSystem>(space)?.FirstOrDefault()?.Type as HeatingSystemType;
            if (heatingSystemType != null)
            {
                string typeName = heatingSystemType.Name;
                if (typeName == "RAD")
                {
                    radiator_Heating = true;
                }
                else if (typeName == "CHB")
                {
                    chilledBeam_Heating = true;
                }
                else if (typeName == "FCU")
                {
                    fanCoilUnit_Heating = true;
                }
                else if (typeName == "RP")
                {
                    chilledBeam_Heating = true;
                }
                else if (typeName == "TRH")
                {
                    radiator_Heating = true;
                }
                else if (typeName == "UFH")
                {
                    radiator_Heating = true;
                }
                else if (typeName == "VRV")
                {
                    dXCoilUnit_Heating = true;
                }
            }

            bool radiator_Cooling = false;
            bool chilledBeam_Cooling = false;
            bool fanCoilUnit_Cooling = false;
            bool dXCoilUnit_Cooling = false;

            CoolingSystemType coolingSystemType = adjacencyCluster?.GetRelatedObjects<Analytical.CoolingSystem>(space)?.FirstOrDefault()?.Type as CoolingSystemType;
            if (coolingSystemType != null)
            {
                string typeName = coolingSystemType.Name;
                if (typeName == "CHB")
                {
                    chilledBeam_Cooling = true;
                }
                else if (typeName == "FCU")
                {
                    fanCoilUnit_Cooling = true;
                }
                else if (typeName == "RP")
                {
                    chilledBeam_Cooling = true;
                }
                else if (typeName == "TRC")
                {
                    chilledBeam_Cooling = true;
                }
                else if (typeName == "UFC")
                {
                    chilledBeam_Cooling = true;
                }
                else if (typeName == "VRV")
                {
                    dXCoilUnit_Cooling = true;
                }
            }

            List<ISystemSpaceComponent> result = new List<ISystemSpaceComponent>();

            if (radiator_Heating || radiator_Cooling)
            {
                SystemRadiator systemRadiator = new SystemRadiator("RAD");

                HeatingSystemCollection heatingSystemCollection = systemPlantRoom?.GetSystemComponents<HeatingSystemCollection>().FirstOrDefault();
                if (heatingSystemCollection != null)
                {
                    systemRadiator.SetValue(SystemRadiatorParameter.HeatingCollection, new CollectionLink(CollectionType.Heating, heatingSystemCollection.Name));
                }

                systemRadiator.Duty = new DesignConditionSizableValue(1, 1.25, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };

                result.Add(systemRadiator);
            }

            if (chilledBeam_Heating || chilledBeam_Cooling)
            {
                SystemChilledBeam systemChilledBeam = new SystemChilledBeam("CHB");

                CoolingSystemCollection coolingSystemCollection = systemPlantRoom.GetSystemComponents<CoolingSystemCollection>().FirstOrDefault();
                if (coolingSystemCollection != null)
                {
                    systemChilledBeam.SetValue(SystemChilledBeamParameter.CoolingCollection, new CollectionLink(CollectionType.Cooling, coolingSystemCollection.Name));
                }

                HeatingSystemCollection heatingSystemCollection = systemPlantRoom.GetSystemComponents<HeatingSystemCollection>().FirstOrDefault();
                if (heatingSystemCollection != null)
                {
                    systemChilledBeam.SetValue(SystemChilledBeamParameter.HeatingCollection, new CollectionLink(CollectionType.Heating, heatingSystemCollection.Name));
                }

                systemChilledBeam.Heating = chilledBeam_Heating;

                if (chilledBeam_Heating)
                {
                    systemChilledBeam.HeatingDuty = new DesignConditionSizableValue(1, 1.25, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };
                }
                else
                {
                    systemChilledBeam.HeatingDuty = new SizableValue() { SizingType = SizingType.Value };
                }

                if (chilledBeam_Cooling)
                {
                    systemChilledBeam.CoolingDuty = new DesignConditionSizableValue(1, 1.15, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };
                }
                else
                {
                    systemChilledBeam.CoolingDuty = new SizableValue() { SizingType = SizingType.Value };
                }

                systemChilledBeam.BypassFactor = 0.0;

                systemChilledBeam.DesignFlowRate = new DesignConditionSizedFlowValue(1, 1, SizingType.Sized, 8, 8, SizedFlowMethod.TemperatureDifference, new string[] { "Annual Design Condition" });
                systemChilledBeam.DesignFlowType = FlowRateType.Sized;

                result.Add(systemChilledBeam);
            }

            if (fanCoilUnit_Heating || fanCoilUnit_Cooling)
            {
                SystemFanCoilUnit systemFanCoilUnit = new SystemFanCoilUnit("FCU");

                CoolingSystemCollection coolingSystemCollection = systemPlantRoom.GetSystemComponents<CoolingSystemCollection>().FirstOrDefault();
                if (coolingSystemCollection != null)
                {
                    systemFanCoilUnit.SetValue(SystemFanCoilUnitParameter.CoolingCollection, new CollectionLink(CollectionType.Cooling, coolingSystemCollection.Name));
                }

                HeatingSystemCollection heatingSystemCollection = systemPlantRoom.GetSystemComponents<HeatingSystemCollection>().FirstOrDefault();
                if (heatingSystemCollection != null)
                {
                    systemFanCoilUnit.SetValue(SystemFanCoilUnitParameter.HeatingCollection, new CollectionLink(CollectionType.Heating, heatingSystemCollection.Name));
                }

                ElectricalSystemCollection electricalSystemCollection = systemPlantRoom.GetSystemComponents<ElectricalSystemCollection>().FirstOrDefault();
                if (electricalSystemCollection != null)
                {
                    systemFanCoilUnit.SetValue(SystemFanCoilUnitParameter.ElectricalCollection, new CollectionLink(CollectionType.Electrical, electricalSystemCollection.Name));
                }

                if (fanCoilUnit_Heating)
                {
                    systemFanCoilUnit.HeatingDuty = new DesignConditionSizableValue(1, 1.25, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };
                }
                else
                {
                    systemFanCoilUnit.HeatingDuty = new SizableValue() { SizingType = SizingType.Value };
                }

                if (fanCoilUnit_Cooling)
                {
                    systemFanCoilUnit.CoolingDuty = new DesignConditionSizableValue(1, 1.15, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };
                }
                else
                {
                    systemFanCoilUnit.CoolingDuty = new SizableValue() { SizingType = SizingType.Value };
                }

                systemFanCoilUnit.BypassFactor = 0.1;

                systemFanCoilUnit.DesignFlowRate = new DesignConditionSizedFlowValue(1, 1, SizingType.Sized, 8, 8, SizedFlowMethod.TemperatureDifference, new string[] { "Annual Design Condition" });
                systemFanCoilUnit.DesignFlowType = FlowRateType.Sized;

                systemFanCoilUnit.OverallEfficiency = new ModifiableValue(0.25);
                systemFanCoilUnit.HeatGainFactor = 1.0;


                TableModifier tableModifier = new TableModifier(ArithmeticOperator.Modulus, new List<string>() { "tpdProfileDataVariablePartload", "value" });
                Dictionary<double, double> dictionary = new Dictionary<double, double>
                {
                    { 0, 0 },
                    { 10, 3 },
                    { 20, 7 },
                    { 30, 13 },
                    { 40, 21 },
                    { 50, 30 },
                    { 60, 41 },
                    { 70, 54 },
                    { 80, 68 },
                    { 90, 83 },
                    { 100, 100 }
                };

                foreach (KeyValuePair<double, double> keyValuePair in dictionary)
                {
                    Dictionary<string, double> dictionary_Temp = new Dictionary<string, double>();
                    dictionary_Temp["tpdProfileDataVariablePartload"] = keyValuePair.Key;
                    dictionary_Temp["value"] = keyValuePair.Value;
                    tableModifier.AddValues(dictionary_Temp);
                }

                systemFanCoilUnit.PartLoad = new ModifiableValue(tableModifier, 0);
                systemFanCoilUnit.Pressure = 100;

                result.Add(systemFanCoilUnit);
            }

            if (dXCoilUnit_Heating || dXCoilUnit_Cooling)
            {
                SystemDXCoilUnit systemDXCoilUnit = new SystemDXCoilUnit("VRV");

                RefrigerantSystemCollection refrigerantSystemCollection = systemPlantRoom.GetSystemComponents<RefrigerantSystemCollection>().FirstOrDefault();
                if (refrigerantSystemCollection != null)
                {
                    systemDXCoilUnit.SetValue(SystemDXCoilUnitParameter.RefrigerantCollection, new CollectionLink(CollectionType.Refrigerant, refrigerantSystemCollection.Name));
                }

                ElectricalSystemCollection electricalSystemCollection = systemPlantRoom.GetSystemComponents<ElectricalSystemCollection>().FirstOrDefault();
                if (electricalSystemCollection != null)
                {
                    systemDXCoilUnit.SetValue(SystemDXCoilUnitParameter.ElectricalCollection, new CollectionLink(CollectionType.Electrical, electricalSystemCollection.Name));
                }

                if(dXCoilUnit_Heating)
                {
                    systemDXCoilUnit.HeatingDuty = new DesignConditionSizableValue(1, 1.25, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };
                }
                else
                {
                    systemDXCoilUnit.HeatingDuty = new SizableValue() { SizingType = SizingType.Value};
                }

                if (dXCoilUnit_Cooling)
                {
                    systemDXCoilUnit.CoolingDuty = new DesignConditionSizableValue(1, 1.15, new string[] { "Annual Design Condition" }) { SizingType = SizingType.Sized, SizeMethod = SizeMethod.Sized };
                }
                else
                {
                    systemDXCoilUnit.CoolingDuty = new SizableValue() { SizingType = SizingType.Value };
                }

                systemDXCoilUnit.BypassFactor = new ModifiableValue(0.1);
                systemDXCoilUnit.OverallEfficiency = new ModifiableValue(0.25);
                systemDXCoilUnit.HeatGainFactor = 1.0;

                TableModifier tableModifier = new TableModifier(ArithmeticOperator.Modulus, new List<string>() { "tpdProfileDataVariablePartload", "value" });
                Dictionary<double, double> dictionary = new Dictionary<double, double>
                {
                    { 0, 0 },
                    { 10, 1 },
                    { 20, 4 },
                    { 30, 8 },
                    { 40, 14 },
                    { 50, 22 },
                    { 60, 32 },
                    { 70, 45 },
                    { 80, 60 },
                    { 90, 78 },
                    { 100, 100 }
                };

                foreach(KeyValuePair<double, double> keyValuePair in dictionary)
                {
                    Dictionary<string, double> dictionary_Temp = new Dictionary<string, double>();
                    dictionary_Temp["tpdProfileDataVariablePartload"] = keyValuePair.Key;
                    dictionary_Temp["value"] = keyValuePair.Value;
                    tableModifier.AddValues(dictionary_Temp);
                }

                systemDXCoilUnit.PartLoad = new ModifiableValue(tableModifier, 0);
                systemDXCoilUnit.Pressure = 100;

                systemDXCoilUnit.BypassFactor = 0.0;

                systemDXCoilUnit.DesignFlowRate = new DesignConditionSizedFlowValue(1, 1, SizingType.Sized, 8, 8, SizedFlowMethod.TemperatureDifference, new string[] { "Annual Design Condition" });
                systemDXCoilUnit.DesignFlowType = FlowRateType.Sized;

                result.Add(systemDXCoilUnit);
            }

            return result;
        }
    }
}
