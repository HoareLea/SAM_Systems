using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidJunction : SystemJunction<LiquidSystem>
    {
        public SystemLiquidJunction()
            : base()
        {

        }

        public SystemLiquidJunction(SystemLiquidJunction systemLiquidJunction)
            : base(systemLiquidJunction)
        {

        }

        public SystemLiquidJunction(JObject jObject)
            : base(jObject)
        {

        }

        public SystemLiquidJunction(string name)
            : base(name)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }
    }
}
