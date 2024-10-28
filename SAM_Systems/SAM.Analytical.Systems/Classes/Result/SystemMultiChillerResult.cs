using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemMultiChillerResult(string uniqueId, string name, string source, Dictionary<MultiChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemMultiChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemMultiChillerResult(SystemMultiChillerResult systemMultiChillerResult)
            : base(systemMultiChillerResult)
        {

        }
    }
}
