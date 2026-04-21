using SAM.Core;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Modify
    {
        public static void SetDefaultValues(this SystemPlantRoom systemPlantRoom, ISystemSpaceComponent systemSpaceComponent)
        {
            if(systemPlantRoom is null || systemSpaceComponent is null)
            {
                return;
            }

            if(systemSpaceComponent is SystemRadiator systemRadiator)
            {
                HeatingSystemCollection heatingSystemCollection = systemPlantRoom.GetSystemComponents<HeatingSystemCollection>().FirstOrDefault();
                if (heatingSystemCollection != null)
                {
                    systemRadiator.SetValue(SystemRadiatorParameter.HeatingCollection, new CollectionLink(CollectionType.Heating, heatingSystemCollection.Name));
                }
            }
            else if (systemSpaceComponent is SystemChilledBeam systemChilledBeam)
            {
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
            }
            else if (systemSpaceComponent is SystemFanCoilUnit systemFanCoilUnit)
            {
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
            }
            else if (systemSpaceComponent is SystemDXCoilUnit systemDXCoilUnit)
            {

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
            }
        }
    }
}