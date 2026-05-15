using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingTowerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemCoolingTowerResult(string uniqueId, string name, string source, Dictionary<CoolingTowerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemCoolingTowerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemCoolingTowerResult(SystemCoolingTowerResult systemCoolingTowerResult)
            : base(systemCoolingTowerResult)
        {

        }
    }
}
