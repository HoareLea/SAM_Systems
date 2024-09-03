using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemMinLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Min;

        public SystemMinLogicalController(string name)
            :base(name)
        {

        }

        public SystemMinLogicalController(SystemMinLogicalController systemMinLogicalController)
            : base(systemMinLogicalController)
        {
            if(systemMinLogicalController != null)
            {

            }
        }

        public SystemMinLogicalController(JObject jObject)
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
