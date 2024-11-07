using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemPumpResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemPumpResult(string uniqueId, string name, string source, Dictionary<PumpDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemPumpResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemPumpResult(SystemPumpResult systemPumpResult)
            : base(systemPumpResult)
        {

        }
    }
}
