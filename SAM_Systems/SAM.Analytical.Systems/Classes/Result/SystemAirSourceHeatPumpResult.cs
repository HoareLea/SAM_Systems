using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemHeatPumpResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemHeatPumpResult(string uniqueId, string name, string source, Dictionary<HeatPumpDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemHeatPumpResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemHeatPumpResult(SystemHeatPumpResult systemHeatPumpResult)
            : base(systemHeatPumpResult)
        {

        }
    }
}
