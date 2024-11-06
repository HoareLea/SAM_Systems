using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystemCollection : SystemCollection<LiquidSystem>
    {
        public RefrigerantSystemCollection()
            : base()
        {
        }

        public RefrigerantSystemCollection(string name)
            : base(name)
        {
        }

        public RefrigerantSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public RefrigerantSystemCollection(RefrigerantSystemCollection refrigerantSystemCollection)
            : base(refrigerantSystemCollection)
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
