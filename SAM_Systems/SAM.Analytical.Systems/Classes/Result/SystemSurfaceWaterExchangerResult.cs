using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSurfaceWaterExchangerResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemSurfaceWaterExchangerResult(string uniqueId, string name, string source, Dictionary<SurfaceWaterExchangerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemSurfaceWaterExchangerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSurfaceWaterExchangerResult(SystemSurfaceWaterExchangerResult systemSurfaceWaterExchangerResult)
            : base(systemSurfaceWaterExchangerResult)
        {

        }
    }
}
