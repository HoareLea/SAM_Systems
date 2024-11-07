using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemBoilerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemBoilerResult(string uniqueId, string name, string source, Dictionary<BoilerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemBoilerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemBoilerResult(SystemBoilerResult systemBoilerResult)
            : base(systemBoilerResult)
        {

        }
    }
}
