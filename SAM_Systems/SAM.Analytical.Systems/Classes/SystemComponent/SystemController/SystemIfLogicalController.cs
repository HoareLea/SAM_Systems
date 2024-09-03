using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemIfLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.If;

        public SystemIfLogicalController(string name)
            :base(name)
        {

        }

        public SystemIfLogicalController(SystemIfLogicalController systemIfLogicalController)
            : base(systemIfLogicalController)
        {
            if(systemIfLogicalController != null)
            {

            }
        }

        public SystemIfLogicalController(JObject jObject)
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
