using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemDXCoilResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemDXCoilResult(string uniqueId, string name, string source, Dictionary<DXCoilDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemDXCoilResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemDXCoilResult(SystemDXCoilResult systemDXCoilResult)
            : base(systemDXCoilResult)
        {

        }
    }
}
