using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class FuelSystemCollection : SystemCollection<FuelSystem>
    {
        public FuelSystemCollection()
            : base()
        {
        }

        public FuelSystemCollection(string name)
            : base(name)
        {
        }

        public FuelSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public FuelSystemCollection(FuelSystemCollection fuelSystemCollection)
            : base(fuelSystemCollection)
        {

        }

        public FuelSystemCollection(System.Guid guid, FuelSystemCollection fuelSystemCollection)
            : base(guid, fuelSystemCollection)
        {

        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new FuelSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
