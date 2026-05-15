using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceDirectAbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterSourceDirectAbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<WaterSourceDirectAbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterSourceDirectAbsorptionChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemWaterSourceDirectAbsorptionChillerResult(SystemWaterSourceDirectAbsorptionChillerResult systemWaterSourceDirectAbsorptionChillerResult)
            : base(systemWaterSourceDirectAbsorptionChillerResult)
        {

        }
    }
}
