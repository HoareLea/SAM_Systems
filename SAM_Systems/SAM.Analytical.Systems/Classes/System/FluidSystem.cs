using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class FluidSystem : SystemObject, IMechanicalSystem
    {
        public FluidSystem(FluidSystem fluidSystem)
            : base(fluidSystem)
        {
        }

        public FluidSystem(System.Guid guid, FluidSystem fluidSystem)
            : base(guid, fluidSystem)
        {
        }

        public FluidSystem(JsonObject jObject)
            : base(jObject)
        {
        }

        public FluidSystem(string name)
            : base(name)
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
    }
}
