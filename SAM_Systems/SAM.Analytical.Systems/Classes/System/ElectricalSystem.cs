using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystem : SystemObject, IElectricalSystem
    {
        public ElectricalSystem(string name)
            : base(name)
        {
        }

        public ElectricalSystem(System.Guid guid, ElectricalSystem electricalSystem)
            : base(guid, electricalSystem)
        {
        }

        public ElectricalSystem(ElectricalSystem electricalSystem)
            : base(electricalSystem)
        {
        }

        public ElectricalSystem(JObject jObject)
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
            return new ElectricalSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
