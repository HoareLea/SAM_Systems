using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemMultiBoilerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemMultiBoilerResult(string uniqueId, string name, string source, Dictionary<MultiBoilerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemMultiBoilerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemMultiBoilerResult(SystemMultiBoilerResult systemMultiBoilerResult)
            : base(systemMultiBoilerResult)
        {

        }
    }
}
