using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class HeatingSystem : LiquidSystem
    {
        public HeatingSystem(HeatingSystem heatingSystem) 
            : base(heatingSystem)
        {
        }

        public HeatingSystem(string name)
            : base(name)
        {
        }

        public HeatingSystem(JObject jObject)
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
