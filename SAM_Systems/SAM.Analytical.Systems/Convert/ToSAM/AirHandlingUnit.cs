
using SAM.Core.Systems;

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

            return new AirHandlingUnit("AHU", double.NaN, double.NaN);

        }
    }
}
