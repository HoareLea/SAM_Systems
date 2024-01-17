using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSteamHumidifierResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemSteamHumidifierResult(string uniqueId, string name, string source, Dictionary<SteamHumidifierDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemSteamHumidifierResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSteamHumidifierResult(SystemSteamHumidifierResult systemSteamHumidifierResult)
            : base(systemSteamHumidifierResult)
        {

        }
    }
}
