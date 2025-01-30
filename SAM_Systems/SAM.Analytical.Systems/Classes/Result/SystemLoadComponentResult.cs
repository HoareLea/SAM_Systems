using Newtonsoft.Json.Linq;
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

        public SystemLoadComponentResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemLoadComponentResult(SystemLoadComponentResult systemLoadComponentResult)
            : base(systemLoadComponentResult)
        {

        }
    }
}
