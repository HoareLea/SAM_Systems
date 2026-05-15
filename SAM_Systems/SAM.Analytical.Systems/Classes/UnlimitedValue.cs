using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public class UnlimitedValue : ISizableValue
    {
        public UnlimitedValue()
        {
        }

        public UnlimitedValue(UnlimitedValue unlimitedValue)
        {
        }

        public UnlimitedValue(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public SizingType SizingType => SizingType.None;
        
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
