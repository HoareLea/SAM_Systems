using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class FuelSystemCollection : SystemCollection<FuelSystem>
    {
        public FuelSystemCollection()
            : base()
        {
        }

        public FuelSystemCollection(string name)
            : base(name)
        {
        }

        public FuelSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public FuelSystemCollection(FuelSystemCollection fuelSystemCollection)
            : base(fuelSystemCollection)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
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

            return result;
        }
    }
}
