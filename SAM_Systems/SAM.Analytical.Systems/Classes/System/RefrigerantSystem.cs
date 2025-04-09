using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystem : FluidSystem
    {
        public RefrigerantSystem(RefrigerantSystem refrigerantSystem) 
            : base(refrigerantSystem)
        {
        }

        public RefrigerantSystem(Guid guid, RefrigerantSystem refrigerantSystem)
            : base(guid, refrigerantSystem)
        {
        }

        public RefrigerantSystem(string name)
            : base(name)
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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new RefrigerantSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
