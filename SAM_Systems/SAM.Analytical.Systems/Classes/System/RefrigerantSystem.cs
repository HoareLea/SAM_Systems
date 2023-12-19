using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystem : FluidSystem
    {
        public RefrigerantSystem(RefrigerantSystem refrigerantSystem) 
            : base(refrigerantSystem)
        {
        }

        public RefrigerantSystem(JObject jObject)
            : base(jObject)
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
