using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class IceStorageChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public IceStorageChillerResult(string uniqueId, string name, string source, Dictionary<IceStorageChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public IceStorageChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public IceStorageChillerResult(IceStorageChillerResult iceStorageChillerResult)
            : base(iceStorageChillerResult)
        {

        }
    }
}
