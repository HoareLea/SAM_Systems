using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemHorizontalExchangerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemHorizontalExchangerResult(string uniqueId, string name, string source, Dictionary<HorizontalExchangerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemHorizontalExchangerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemHorizontalExchangerResult(SystemHorizontalExchangerResult systemHorizontalExchangerResult)
            : base(systemHorizontalExchangerResult)
        {

        }
    }
}
