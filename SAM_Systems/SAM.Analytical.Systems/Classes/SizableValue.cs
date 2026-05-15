using System.Text.Json.Nodes;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SizableValue : ISizableValue
    {
        public SizingType SizingType { get; set; }
        public double SizeFraction { get; set; }
        public SizeMethod SizeMethod { get; set; } = SizeMethod.Normal;
        public virtual ModifiableValue ModifiableValue { get; set; }

        public SizableValue()
        {
        }

        public SizableValue(double value)
        {
            ModifiableValue = value;
        }

        public SizableValue(double value, double sizeFraction)
        {
            ModifiableValue = value;
            SizeFraction = sizeFraction;
        }

        public SizableValue(SizableValue sizableValue)
        {
            if(sizableValue != null)
            {
                SizingType = sizableValue.SizingType;
                ModifiableValue = sizableValue.ModifiableValue;
                SizeFraction = sizableValue.SizeFraction;
                SizeMethod = sizableValue.SizeMethod;
            }
        }

        public SizableValue(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("SizingType"))
            {
                SizingType = Core.Query.Enum<SizingType>(jObject["SizingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("SizeFraction"))
            {
                SizeFraction = jObject["SizeFraction"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("SizeMethod"))
            {
                SizeMethod = Core.Query.Enum<SizeMethod>(jObject["SizeMethod"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ModifiableValue"))
            {
                ModifiableValue = Core.Query.IJSAMObject<ModifiableValue>(jObject["ModifiableValue"] as JsonObject);
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            result.Add("SizingType", SizingType.ToString());

            if (!double.IsNaN(SizeFraction))
            {
                result.Add("SizeFraction", SizeFraction);
            }

            result.Add("SizeMethod", SizeMethod.ToString());

            if (ModifiableValue != null)
            {
                result.Add("ModifiableValue", ModifiableValue.ToJsonObject());
            }

            return result;
        }
    }
}
