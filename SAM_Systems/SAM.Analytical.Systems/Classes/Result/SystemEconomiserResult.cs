using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemEconomiserResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemEconomiserResult(string uniqueId, string name, string source, Dictionary<EconomiserDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemEconomiserResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemEconomiserResult(SystemEconomiserResult systemEconomiserResult)
            : base(systemEconomiserResult)
        {

        }
    }
}
