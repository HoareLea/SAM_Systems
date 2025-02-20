using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidJunction : SystemJunction<LiquidSystem>, ILiquidSystemComponent
    {
        public double MainsPressure { get; set; }
        
        public SystemLiquidJunction()
            : base()
        {

        }

        public SystemLiquidJunction(SystemLiquidJunction systemLiquidJunction)
            : base(systemLiquidJunction)
        {
            if(systemLiquidJunction != null)
            {
                MainsPressure = systemLiquidJunction.MainsPressure;
            }
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
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("MainsPressure"))
            {
                MainsPressure = jObject.Value<double>("MainsPressure");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if(!double.IsNaN(MainsPressure))
            {
                result.Add("MainsPressure", MainsPressure);
            }

            return result;
        }
    }
}
