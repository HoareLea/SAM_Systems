using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemDirectEvaporativeCoolerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemDirectEvaporativeCoolerResult(string uniqueId, string name, string source, Dictionary<DirectEvaporativeCoolerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemDirectEvaporativeCoolerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemDirectEvaporativeCoolerResult(SystemDirectEvaporativeCoolerResult systemDirectEvaporativeCoolerResult)
            : base(systemDirectEvaporativeCoolerResult)
        {

        }
    }
}
