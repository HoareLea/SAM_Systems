using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceHeatPumpResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterSourceHeatPumpResult(string uniqueId, string name, string source, Dictionary<WaterSourceHeatPumpDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterSourceHeatPumpResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemWaterSourceHeatPumpResult(SystemWaterSourceHeatPumpResult systemWaterSourceHeatPumpResult)
            : base(systemWaterSourceHeatPumpResult)
        {

        }
    }
}

