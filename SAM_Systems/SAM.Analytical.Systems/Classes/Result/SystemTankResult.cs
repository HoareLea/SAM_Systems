using Newtonsoft.Json.Linq;
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

        public SystemCoolingTowerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemCoolingTowerResult(SystemCoolingTowerResult systemCoolingTowerResult)
            : base(systemCoolingTowerResult)
        {

        }
    }
}
