using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemFanCoilUnitResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemFanCoilUnitResult(string uniqueId, string name, string source, Dictionary<FanCoilUnitDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Query.Dictionary(dictionary))
        {
        }

        public SystemFanCoilUnitResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemFanCoilUnitResult(SystemFanCoilUnitResult systemFanCoilUnitResult)
            : base(systemFanCoilUnitResult)
        {

        }
    }
}
