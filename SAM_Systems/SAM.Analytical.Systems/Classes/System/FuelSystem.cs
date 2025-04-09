using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class FuelSystem : FluidSystem, IMechanicalSystem
    {
        public FuelSystem(FuelSystem fuelSystem)
            : base(fuelSystem)
        {
        }

        public FuelSystem(System.Guid guid, FuelSystem fuelSystem)
            : base(guid, fuelSystem)
        {
        }

        public FuelSystem(JObject jObject)
            : base(jObject)
        {
        }

        public FuelSystem(string name)
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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new FuelSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}