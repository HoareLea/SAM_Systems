using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemChilledBeamResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemChilledBeamResult(string uniqueId, string name, string source, Dictionary<ChilledBeamDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemChilledBeamResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemChilledBeamResult(SystemChilledBeamResult systemChilledBeamResult)
            : base(systemChilledBeamResult)
        {

        }
    }
}
