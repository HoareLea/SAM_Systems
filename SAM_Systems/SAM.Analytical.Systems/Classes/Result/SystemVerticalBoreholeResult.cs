using Newtonsoft.Json.Linq;
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

        public SystemVerticalBoreholeResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemVerticalBoreholeResult(SystemVerticalBoreholeResult systemVerticalBoreholeResult)
            : base(systemVerticalBoreholeResult)
        {

        }
    }
}
