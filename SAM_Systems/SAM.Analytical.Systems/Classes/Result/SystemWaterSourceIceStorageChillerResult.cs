using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceIceStorageChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterSourceIceStorageChillerResult(string uniqueId, string name, string source, Dictionary<WaterSourceIceStorageChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterSourceIceStorageChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemWaterSourceIceStorageChillerResult(SystemWaterSourceIceStorageChillerResult waterSourceIceStorageChillerResult)
            : base(waterSourceIceStorageChillerResult)
        {

        }
    }
}
