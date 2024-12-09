using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSignalControllerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemSignalControllerResult(string uniqueId, string name, string source, Dictionary<SignalControllerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemSignalControllerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSignalControllerResult(SystemSignalControllerResult systemSignalControllerResult)
            : base(systemSignalControllerResult)
        {

        }
    }
}
