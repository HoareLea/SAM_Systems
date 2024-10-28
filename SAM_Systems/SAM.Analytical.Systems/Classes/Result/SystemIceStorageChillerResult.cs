using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemIceStorageChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemIceStorageChillerResult(string uniqueId, string name, string source, Dictionary<IceStorageChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemIceStorageChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemIceStorageChillerResult(SystemIceStorageChillerResult systemIceStorageChillerResult)
            : base(systemIceStorageChillerResult)
        {

        }
    }
}
