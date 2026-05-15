using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterSourceChillerResult(string uniqueId, string name, string source, Dictionary<WaterSourceChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterSourceChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemWaterSourceChillerResult(SystemWaterSourceChillerResult systemWaterSourceChillerResult)
            : base(systemWaterSourceChillerResult)
        {

        }
    }
}
