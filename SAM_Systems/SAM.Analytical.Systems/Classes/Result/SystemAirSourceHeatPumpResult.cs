using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemAirSourceHeatPumpResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemAirSourceHeatPumpResult(string uniqueId, string name, string source, Dictionary<AirSourceHeatPumpDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemAirSourceHeatPumpResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemAirSourceHeatPumpResult(SystemAirSourceHeatPumpResult systemAirSourceHeatPumpResult)
            : base(systemAirSourceHeatPumpResult)
        {

        }
    }
}