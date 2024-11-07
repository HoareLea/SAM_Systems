using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemValveResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemValveResult(string uniqueId, string name, string source, Dictionary<ValveDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemValveResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemValveResult(SystemValveResult systemValveResult)
            : base(systemValveResult)
        {

        }
    }
}
