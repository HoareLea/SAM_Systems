using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemLoadComponentResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemLoadComponentResult(string uniqueId, string name, string source, Dictionary<LoadComponentDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemLoadComponentResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemLoadComponentResult(SystemLoadComponentResult systemLoadComponentResult)
            : base(systemLoadComponentResult)
        {

        }
    }
}
