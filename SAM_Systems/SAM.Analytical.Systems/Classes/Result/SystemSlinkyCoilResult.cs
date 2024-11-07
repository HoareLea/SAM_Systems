using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSlinkyCoilResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemSlinkyCoilResult(string uniqueId, string name, string source, Dictionary<SlinkyCoilDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemSlinkyCoilResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSlinkyCoilResult(SystemSlinkyCoilResult systemSlinkyCoilResult)
            : base(systemSlinkyCoilResult)
        {

        }
    }
}
