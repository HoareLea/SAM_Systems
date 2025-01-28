using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public abstract class SystemController : SystemComponent, ISystemController
    {
        public HashSet<string> DayTypeNames { get; set; }

        public SystemController(string name)
            : base(name)
        {

        }

        public SystemController(SystemController systemController)
            : base(systemController)
        {
            if (systemController != null)
            {
                DayTypeNames = systemController.DayTypeNames == null ? null : new HashSet<string>(systemController.DayTypeNames);
            }
        }

        public SystemController(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("DayTypeNames"))
            {
                JArray jArray = jObject.Value<JArray>("DayTypeNames");
                if(jArray != null)
                {
                    DayTypeNames = new HashSet<string>();
                    foreach(string dayTypeName in jArray)
                    {
                        DayTypeNames.Add(dayTypeName);
                    }
                }
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if(DayTypeNames != null)
            {
                JArray jArray = new JArray();
                foreach (string dayTypeName in DayTypeNames)
                {
                    jArray.Add(dayTypeName);
                }

                result.Add("DayTypeNames", jArray);
            }

            return result;
        }
    }
}
