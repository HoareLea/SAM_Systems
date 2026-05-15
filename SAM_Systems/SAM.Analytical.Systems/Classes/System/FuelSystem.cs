using System.Text.Json.Nodes;
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

        public FuelSystem(JsonObject jObject)
            : base(jObject)
        {
        }

        public FuelSystem(string name)
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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new FuelSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}