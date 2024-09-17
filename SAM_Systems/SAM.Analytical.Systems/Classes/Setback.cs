using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public abstract class Setback : ISetback
    {
        private string scheduleName;

        public Setback()
        {

        }

        public Setback(string scheduleName)
        {
            this.scheduleName = scheduleName;
        }

        public Setback(Setback setback)
        {
            if(setback != null)
            {
                scheduleName = setback.scheduleName;
            }
        }

        public Setback(JObject jObject)
        {
            FromJObject(jObject);
        }

        public string ScheduleName
        {
            get
            {
                return scheduleName;
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("ScheduleName"))
            {
                scheduleName = jObject.Value<string>("ScheduleName");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (scheduleName != null)
            {
                result.Add("ScheduleName", scheduleName);
            }

            return result;
        }
    }
}
