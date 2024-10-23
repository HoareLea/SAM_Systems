using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystemGroup : SystemGroup<RefrigerantSystem>
    {
        public RefrigerantSystemGroup()
            : base()
        {
        }

        public RefrigerantSystemGroup(string name)
            : base(name)
        {
        }

        public RefrigerantSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public RefrigerantSystemGroup(RefrigerantSystemGroup refrigerantSystemGroup)
            : base(refrigerantSystemGroup)
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
