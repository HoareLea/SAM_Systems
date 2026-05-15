using System.Text.Json.Nodes;
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

        public SystemWaterToWaterHeatPumpResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemWaterToWaterHeatPumpResult(SystemWaterToWaterHeatPumpResult systemWaterToWaterHeatPumpResult)
            : base(systemWaterToWaterHeatPumpResult)
        {

        }
    }
}