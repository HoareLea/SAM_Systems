using System.Text.Json.Nodes;
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

        public SystemController(System.Guid guid, SystemController systemController)
            : base(guid, systemController)
        {
            if (systemController != null)
            {
                DayTypeNames = systemController.DayTypeNames == null ? null : new HashSet<string>(systemController.DayTypeNames);
            }
        }

        public SystemController(JsonObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("DayTypeNames"))
            {
                JsonArray jArray = jObject["DayTypeNames"] as JsonArray;
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

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if(DayTypeNames != null)
            {
                JsonArray jArray = new JsonArray();
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
