using System.Text.Json.Nodes;
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

        public Setback(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public string ScheduleName
        {
            get
            {
                return scheduleName;
            }
        }

        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("ScheduleName"))
            {
                scheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (scheduleName != null)
            {
                result.Add("ScheduleName", scheduleName);
            }

            return result;
        }
    }
}
