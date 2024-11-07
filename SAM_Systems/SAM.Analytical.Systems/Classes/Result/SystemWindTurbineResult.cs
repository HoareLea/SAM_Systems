using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWindTurbineResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemWindTurbineResult(string uniqueId, string name, string source, Dictionary<WindTurbineDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWindTurbineResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemWindTurbineResult(SystemWindTurbineResult systemWindTurbineResult)
            : base(systemWindTurbineResult)
        {

        }
    }
}
