using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemDXCoilUnitResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemDXCoilUnitResult(string uniqueId, string name, string source, Dictionary<DXCoilUnitDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Query.Dictionary(dictionary))
        {
        }

        public SystemDXCoilUnitResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemDXCoilUnitResult(SystemDXCoilUnitResult systemDXCoilUnitResult)
            : base(systemDXCoilUnitResult)
        {

        }
    }
}
