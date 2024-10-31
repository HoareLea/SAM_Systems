using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystemCollection : SystemCollection<ElectricalSystem>
    {
        public ElectricalSystemCollection()
            : base()
        {
        }

        public ElectricalSystemCollection(string name)
            : base(name)
        {
        }

        public ElectricalSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public ElectricalSystemCollection(ElectricalSystemCollection electricalSystemCollection)
            : base(electricalSystemCollection)
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
