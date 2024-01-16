using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingCoilResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemCoolingCoilResult(string uniqueId, string name, string source, Dictionary<CoolingCoilDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemCoolingCoilResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemCoolingCoilResult(SystemCoolingCoilResult systemCoolingCoilResult)
            : base(systemCoolingCoilResult)
        {

        }
    }
}
