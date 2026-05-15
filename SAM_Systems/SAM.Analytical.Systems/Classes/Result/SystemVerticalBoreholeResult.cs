using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemVerticalBoreholeResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemVerticalBoreholeResult(string uniqueId, string name, string source, Dictionary<VerticalBoreholeDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemVerticalBoreholeResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemVerticalBoreholeResult(SystemVerticalBoreholeResult systemVerticalBoreholeResult)
            : base(systemVerticalBoreholeResult)
        {

        }
    }
}
