using SAM.Core.Systems;
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

            SystemExchanger systemExchanger = systemPlantRoom.GetSystemComponents<SystemExchanger>(airSystem)?.FirstOrDefault();
            if(systemExchanger == null)
            {
                
            }
            else
            {
                List<ISystemComponent> systemComponents = systemPlantRoom.GetRelatedObjects<ISystemComponent>(systemExchanger);
            }

            AirHandlingUnit result = new AirHandlingUnit("AHU", double.NaN, double.NaN);

            return result;
        }
    }
}
