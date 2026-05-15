using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemChiller : SystemComponent, ILiquidSystemComponent
    {
        public ISizableValue Duty { get; set; }

        public SystemChiller(string name)
            : base(name)
        {

        }

        public SystemChiller(SystemChiller systemChiller)
            : base(systemChiller)
        {
            if(systemChiller != null)
            {
                Duty = systemChiller.Duty?.Clone();
            }
        }

        public SystemChiller(System.Guid guid, SystemChiller systemChiller)
            : base(guid, systemChiller)
        {
            if (systemChiller != null)
            {
                Duty = systemChiller.Duty?.Clone();
            }
        }

        public SystemChiller(JsonObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            return result;
        }
    }
}

