using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemFanResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemFanResult(string uniqueId, string name, string source, Dictionary<FanDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemFanResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemFanResult(SystemFanResult systemFanResult)
            : base(systemFanResult)
        {

        }
    }
}
