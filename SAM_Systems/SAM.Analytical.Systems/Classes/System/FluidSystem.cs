using Newtonsoft.Json.Linq;
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

        public FluidSystem(JObject jObject)
            : base(jObject)
        {
        }

        public FluidSystem(string name)
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
