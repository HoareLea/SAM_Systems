using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemValueControllerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemValueControllerResult(string uniqueId, string name, string source, Dictionary<ValueControllerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemValueControllerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemValueControllerResult(SystemValueControllerResult systemValueControllerResult)
            : base(systemValueControllerResult)
        {

        }
    }
}
