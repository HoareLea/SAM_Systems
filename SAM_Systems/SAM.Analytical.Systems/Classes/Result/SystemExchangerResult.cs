using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidExchangerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemLiquidExchangerResult(string uniqueId, string name, string source, Dictionary<LiquidExchangerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemLiquidExchangerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemLiquidExchangerResult(SystemLiquidExchangerResult systemLiquidExchangerResult)
            : base(systemLiquidExchangerResult)
        {

        }
    }
}
