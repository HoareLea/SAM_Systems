using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class ControlSystem : SystemObject, IControlSystem
    {
        public ControlSystem(ControlSystem controlSystem)
            : base(controlSystem)
        {
        }

        public ControlSystem(System.Guid guid, ControlSystem controlSystem)
            : base(guid, controlSystem)
        {
        }

        public ControlSystem(JObject jObject)
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
            return new ControlSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
