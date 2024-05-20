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
                
                List<ISystemComponent> systemComponents_Space = systemComponents.FindAll(x => Query.ContainsSystemSpaceComponent(systemPlantRoom, x));
                if(systemComponents_Space == null || systemComponents_Space.Count == 0)
                {
                    ISystemComponent systemComponent = systemPlantRoom.GetSystemComponents<ISystemComponent>(airSystem, ConnectorStatus.Unconnected, Core.Direction.In)?.FirstOrDefault();
                    if(systemComponent == null)
                    {
                        return result;
                    }

                    List<SystemComponent> systemComponents_Temp = systemPlantRoom.GetOrderedSystemComponents(systemComponent as SystemComponent, airSystem, Core.Direction.Out);
                    if(systemComponents_Temp == null || systemComponents_Temp.Count == 0)

                    {
                        return result;
                    }
                }
                else
                {
                    foreach(ISystemComponent systemComponent_Space in systemComponents_Space)
                    {
                        List<SystemComponent> systemComponents_Temp = systemPlantRoom.GetOrderedSystemComponents(systemComponent_Space as SystemComponent, airSystem, Core.Direction.In);
                        if(systemComponents_Temp == null || systemComponents_Temp.Count == 0)
                        {
                            continue;
                        }


                    
                    }


                }
            }




            //SystemExchanger systemExchanger = 
            //if(systemExchanger == null)
            //{
                
            //}
            //else
            //{
            //    List<ISystemComponent> systemComponents = systemPlantRoom.GetRelatedObjects<ISystemComponent>(systemExchanger);

            //    List<ISimpleEquipment> simpleEquipments = null;

            //    HeatRecoveryUnit heatRecoveryUnit = new HeatRecoveryUnit(systemExchanger.Name, 76, 0, 76, 0, double.NaN, double.NaN, double.NaN, double.NaN);

            //    simpleEquipments = new List<ISimpleEquipment>();
            //    simpleEquipments.Add(heatRecoveryUnit);
            //    result.AddSimpleEquipments(FlowClassification.Supply, simpleEquipments.ToArray());

            //    simpleEquipments = new List<ISimpleEquipment>();
            //    simpleEquipments.Add(heatRecoveryUnit);
            //    result.AddSimpleEquipments(FlowClassification.Extract, simpleEquipments.ToArray());
            //}

            return result;
        }
    }
}
