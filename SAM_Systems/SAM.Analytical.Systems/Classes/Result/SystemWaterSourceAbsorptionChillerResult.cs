using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceAbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterSourceAbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<WaterSourceAbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterSourceAbsorptionChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemWaterSourceAbsorptionChillerResult(SystemWaterSourceAbsorptionChillerResult systemWaterSourceAbsorptionChillerResult)
            : base(systemWaterSourceAbsorptionChillerResult)
        {

        }
    }
}
