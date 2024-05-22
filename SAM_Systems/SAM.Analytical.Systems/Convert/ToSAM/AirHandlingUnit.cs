using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Convert
    {
        public static AirHandlingUnit ToSAM(this SystemPlantRoom systemPlantRoom, AirSystem airSystem)
        {
            if(systemPlantRoom == null || airSystem == null)
            {
                return null; 
            }

            //TODO: [JAKUB] Implement conversion here

            AirHandlingUnit result = new AirHandlingUnit("AHU", double.NaN, double.NaN);

            List<ISystemComponent> systemComponents = systemPlantRoom.GetSystemComponents<ISystemComponent>(airSystem);
            if(systemComponents != null && systemComponents.Count != 0)
            {
                Dictionary<Guid, SimpleEquipment> dictionary = new Dictionary<Guid, SimpleEquipment>(); 
                
                List<ISystemComponent> systemComponents_Space = systemComponents.FindAll(x => Query.ContainsSystemSpace(systemPlantRoom, x));
                if(systemComponents_Space == null || systemComponents_Space.Count == 0)
                {
                    ISystemComponent systemComponent = systemPlantRoom.GetSystemComponents<ISystemComponent>(airSystem, ConnectorStatus.Unconnected, Core.Direction.In)?.FirstOrDefault();
                    if(systemComponent == null)
                    {
                        return result;
                    }

                    List<SystemComponent> systemComponents_Ordered = systemPlantRoom.GetOrderedSystemComponents(systemComponent as SystemComponent, airSystem, Core.Direction.Out);
                    if(systemComponents_Ordered == null || systemComponents_Ordered.Count == 0)
                    {
                        return result;
                    }

                    List<ISimpleEquipment> simpleEquipments = new List<ISimpleEquipment>();

                    foreach (SystemComponent systemComponent_Ordered in systemComponents_Ordered)
                    {
                        SimpleEquipment simpleEquipment = systemComponent_Ordered.ToSAM();
                        if (simpleEquipment == null)
                        {
                            continue;
                        }

                        simpleEquipments.Add(simpleEquipment);
                    }

                    result.AddSimpleEquipments(FlowClassification.Extract, simpleEquipments.ToArray());

                }
                else
                {
                    List<SystemComponent> systemComponents_Top = Geometry.Systems.Query.TopSystemComponents(systemPlantRoom, systemComponents_Space.ConvertAll(x => x as SystemComponent), new SystemType(airSystem));

                    Tuple<Core.Direction, FlowClassification>[] tuples = new Tuple<Core.Direction, FlowClassification>[] { new Tuple<Core.Direction, FlowClassification>(Core.Direction.Out, FlowClassification.Extract), new Tuple<Core.Direction, FlowClassification>(Core.Direction.In, FlowClassification.Supply) };

                    foreach (ISystemComponent systemComponent_Space in systemComponents_Top)
                    {
                        foreach(Tuple<Core.Direction, FlowClassification> tuple in tuples)
                        {
                            List<SystemComponent> systemComponents_Ordered = systemPlantRoom.GetOrderedSystemComponents(systemComponent_Space as SystemComponent, airSystem, tuple.Item1);
                            if (systemComponents_Ordered == null || systemComponents_Ordered.Count == 0)
                            {
                                continue;
                            }

                            systemComponents_Ordered.Reverse();

                            List<ISimpleEquipment> simpleEquipments = new List<ISimpleEquipment>();

                            foreach (SystemComponent systemComponent_Ordered in systemComponents_Ordered)
                            {
                                if (!dictionary.TryGetValue(systemComponent_Ordered.Guid, out SimpleEquipment simpleEquipment))
                                {
                                    simpleEquipment = systemComponent_Ordered.ToSAM();
                                    if (simpleEquipment == null)
                                    {
                                        continue;
                                    }

                                    dictionary[systemComponent_Ordered.Guid] = simpleEquipment;
                                }

                                simpleEquipments.Add(simpleEquipment);
                            }

                            result.AddSimpleEquipments(tuple.Item2, simpleEquipments.ToArray());
                        }
                    }
                }
            }

            return result;
        }


        public static SimpleEquipment ToSAM(this SystemComponent systemComponent)
        {
            if(systemComponent == null)
            {
                return null;
            }

            if(systemComponent is SystemCoolingCoil)
            {
                return ToSAM((SystemCoolingCoil)systemComponent);
            }

            if (systemComponent is SystemHeatingCoil)
            {
                return ToSAM((SystemHeatingCoil)systemComponent);
            }

            if (systemComponent is SystemHumidifier)
            {
                return ToSAM((SystemHumidifier)systemComponent);
            }

            if (systemComponent is SystemFan)
            {
                return ToSAM((SystemFan)systemComponent);
            }

            if (systemComponent is SystemExchanger)
            {
                return ToSAM((SystemExchanger)systemComponent);
            }

            return null;
        }

        public static CoolingCoil ToSAM(this SystemCoolingCoil systemCoolingCoil)
        {
            if(systemCoolingCoil == null)
            {
                return null;
            }

            return new CoolingCoil(double.NaN, double.NaN, double.NaN, double.NaN);
        }

        public static HeatingCoil ToSAM(this SystemHeatingCoil systemHeatingCoil)
        {
            if (systemHeatingCoil == null)
            {
                return null;
            }

            return new HeatingCoil(double.NaN, double.NaN, double.NaN, double.NaN);
        }

        public static Humidifier ToSAM(this SystemHumidifier systemHumidifier)
        {
            if (systemHumidifier == null)
            {
                return null;
            }

            return new Humidifier(systemHumidifier.Name);
        }

        public static Fan ToSAM(this SystemFan systemFan)
        {
            if (systemFan == null)
            {
                return null;
            }

            return new Fan(systemFan.Name);
        }

        public static HeatRecoveryUnit ToSAM(this SystemExchanger systemExchanger)
        {
            if (systemExchanger == null)
            {
                return null;
            }

            return new HeatRecoveryUnit(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN);
        }
    }
}
