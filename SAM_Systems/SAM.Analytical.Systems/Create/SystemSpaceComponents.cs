using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static List<ISystemSpaceComponent> SystemSpaceComponents(this AdjacencyCluster adjacencyCluster, Space space)
        {
            ISystemSpaceComponent systemSpaceComponent_Heating = null;

            HeatingSystemType heatingSystemType = adjacencyCluster?.GetRelatedObjects<Analytical.HeatingSystem>(space)?.FirstOrDefault()?.Type as HeatingSystemType;
            if (heatingSystemType != null)
            {
                string typeName = heatingSystemType.Name;
                if (typeName == "RAD")
                {
                    systemSpaceComponent_Heating = new SystemRadiator(typeName);
                }
                else if (typeName == "CHB")
                {
                    systemSpaceComponent_Heating = new SystemChilledBeam(typeName);
                }
                else if (typeName == "FCU")
                {
                    systemSpaceComponent_Heating = new SystemFanCoilUnit(typeName);
                }
                else if (typeName == "RP")
                {
                    systemSpaceComponent_Heating = new SystemChilledBeam(typeName);
                }
                else if (typeName == "TRH")
                {
                    systemSpaceComponent_Heating = new SystemRadiator(typeName);
                }
                else if (typeName == "UFH")
                {
                    systemSpaceComponent_Heating = new SystemRadiator(typeName);
                }
                else if (typeName == "VRV")
                {
                    systemSpaceComponent_Heating = new SystemDXCoilUnit(typeName);
                }
            }

            ISystemSpaceComponent systemSpaceComponent_Cooling = null;

            CoolingSystemType coolingSystemType = adjacencyCluster?.GetRelatedObjects<Analytical.CoolingSystem>(space)?.FirstOrDefault()?.Type as CoolingSystemType;
            if (coolingSystemType != null)
            {
                string typeName = coolingSystemType.Name;
                if (typeName == "CHB")
                {
                    systemSpaceComponent_Cooling = new SystemChilledBeam(typeName);
                }
                else if (typeName == "FCU")
                {
                    systemSpaceComponent_Cooling = new SystemFanCoilUnit(typeName);
                }
                else if (typeName == "RP")
                {
                    systemSpaceComponent_Cooling = new SystemChilledBeam(typeName);
                }
                else if (typeName == "TRC")
                {
                    systemSpaceComponent_Cooling = new SystemChilledBeam(typeName);
                }
                else if (typeName == "UFC")
                {
                    systemSpaceComponent_Cooling = new SystemChilledBeam(typeName);
                }
                else if (typeName == "VRV")
                {
                    systemSpaceComponent_Cooling = new SystemDXCoilUnit(typeName);
                }
            }

            List<ISystemSpaceComponent> result = new List<ISystemSpaceComponent>();

            if (systemSpaceComponent_Heating != null)
            {
                result.Add(systemSpaceComponent_Heating);
            }

            if (systemSpaceComponent_Cooling != null && systemSpaceComponent_Cooling.GetType() != systemSpaceComponent_Heating?.GetType())
            {
                result.Add(systemSpaceComponent_Cooling);
            }

            return result;
        }
    }
}
