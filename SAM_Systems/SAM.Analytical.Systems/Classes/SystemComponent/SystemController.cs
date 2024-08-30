using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemController : SystemComponent
    {
        public SystemController(string name)
            : base(name)
        {

        }

        public SystemController(SystemController systemController)
            : base(systemController)
        {
            if (systemController != null)
            {

            }
        }

        public SystemController(JObject jObject)
            : base(jObject)
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
