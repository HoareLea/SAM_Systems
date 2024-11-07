using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemTankResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemTankResult(string uniqueId, string name, string source, Dictionary<TankDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemTankResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemTankResult(SystemTankResult systemTankResult)
            : base(systemTankResult)
        {

        }
    }
}
