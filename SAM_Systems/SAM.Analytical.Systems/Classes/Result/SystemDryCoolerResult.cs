using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemDryCoolerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemDryCoolerResult(string uniqueId, string name, string source, Dictionary<DryCoolerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemDryCoolerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemDryCoolerResult(SystemPumpResult systemPumpResult)
            : base(systemPumpResult)
        {

        }
    }
}
