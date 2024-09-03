using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemSigLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Sig;

        public SystemSigLogicalController(string name)
            :base(name)
        {

        }

        public SystemSigLogicalController(SystemSigLogicalController systemSigLogicalController)
            : base(systemSigLogicalController)
        {
            if(systemSigLogicalController != null)
            {

            }
        }

        public SystemSigLogicalController(JObject jObject)
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
