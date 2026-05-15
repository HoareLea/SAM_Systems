using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public abstract class Setpoint : ISetpoint
    {
        public Setpoint()
        {

        }

        public Setpoint(Setpoint setpoint)
        {

        }

        public Setpoint(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            return result;
        }
    }
}
