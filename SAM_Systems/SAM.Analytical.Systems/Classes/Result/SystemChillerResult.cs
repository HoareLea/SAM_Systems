using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemChillerResult(string uniqueId, string name, string source, Dictionary<ChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemChillerResult(SystemChillerResult systemChillerResult)
            : base(systemChillerResult)
        {

        }
    }
}
