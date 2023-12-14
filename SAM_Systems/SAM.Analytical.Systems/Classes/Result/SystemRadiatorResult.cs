using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemRadiatorResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemRadiatorResult(string uniqueId, string name, string source, IndexedDoubles heatingLoads)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(RadiatorDataType.HeatingLoad, heatingLoads))
        {
        }

        public SystemRadiatorResult(string uniqueId, string name, string source, Dictionary<RadiatorDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemRadiatorResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemRadiatorResult(SystemRadiatorResult systemRadiatorResult)
            : base(systemRadiatorResult)
        {

        }
    }
}
