using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemCHPResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemCHPResult(string uniqueId, string name, string source, Dictionary<CHPDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemCHPResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemCHPResult(SystemCHPResult systemCHPResult)
            : base(systemCHPResult)
        {

        }
    }
}
