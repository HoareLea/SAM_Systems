using System.Text.Json.Nodes;
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

        public ControlSystem(JsonObject jObject)
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
            return new ControlSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
