using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemDesiccantWheelResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemDesiccantWheelResult(string uniqueId, string name, string source, Dictionary<DesiccantWheelDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemDesiccantWheelResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemDesiccantWheelResult(SystemDesiccantWheelResult systemDesiccantWheelResult)
            : base(systemDesiccantWheelResult)
        {

        }
    }
}
