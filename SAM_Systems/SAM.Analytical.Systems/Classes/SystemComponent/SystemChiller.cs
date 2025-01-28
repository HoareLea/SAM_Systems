using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemChiller : SystemComponent
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

        public SystemChiller(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            return result;
        }
    }
}

