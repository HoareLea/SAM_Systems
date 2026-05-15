using System.Text.Json.Nodes;
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

        public SystemHorizontalExchangerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemHorizontalExchangerResult(SystemHorizontalExchangerResult systemHorizontalExchangerResult)
            : base(systemHorizontalExchangerResult)
        {

        }
    }
}
