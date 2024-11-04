using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemExchangerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemExchangerResult(string uniqueId, string name, string source, Dictionary<ExchangerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemExchangerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemExchangerResult(SystemExchangerResult systemExchangerResult)
            : base(systemExchangerResult)
        {

        }
    }
}
