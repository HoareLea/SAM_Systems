using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class CoolingSystemCollection : SystemCollection<CoolingSystem>
    {
        public CoolingSystemCollection()
            : base()
        {
        }

        public CoolingSystemCollection(string name)
            : base(name)
        {
        }

        public CoolingSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public CoolingSystemCollection(CoolingSystemCollection coolingSystemCollection)
            : base(coolingSystemCollection)
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
