using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemPipeLossComponentResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemPipeLossComponentResult(string uniqueId, string name, string source, Dictionary<PipeLossComponentDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemPipeLossComponentResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemPipeLossComponentResult(SystemPipeLossComponentResult systemPipeLossComponentResult)
            : base(systemPipeLossComponentResult)
        {

        }
    }
}
