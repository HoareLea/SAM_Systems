using System.Text.Json.Nodes;
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

        public SystemCHPResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemCHPResult(SystemCHPResult systemCHPResult)
            : base(systemCHPResult)
        {

        }
    }
}
