using System.Text.Json.Nodes;
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

        public RefrigerantSystem(JsonObject jObject)
            : base(jObject)
        {
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            return base.ToJsonObject();
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new RefrigerantSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
