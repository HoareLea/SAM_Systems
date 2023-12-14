using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemChilledBeamResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemChilledBeamResult(string uniqueId, string name, string source, Dictionary<ChilledBeamDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemChilledBeamResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemChilledBeamResult(SystemChilledBeamResult systemChilledBeamResult)
            : base(systemChilledBeamResult)
        {

        }
    }
}
