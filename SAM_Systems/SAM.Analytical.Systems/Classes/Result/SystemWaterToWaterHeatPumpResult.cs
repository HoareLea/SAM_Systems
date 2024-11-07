using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterToWaterHeatPumpResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterToWaterHeatPumpResult(string uniqueId, string name, string source, Dictionary<WaterToWaterHeatPumpDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterToWaterHeatPumpResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemWaterToWaterHeatPumpResult(SystemWaterToWaterHeatPumpResult systemWaterToWaterHeatPumpResult)
            : base(systemWaterToWaterHeatPumpResult)
        {

        }
    }
}