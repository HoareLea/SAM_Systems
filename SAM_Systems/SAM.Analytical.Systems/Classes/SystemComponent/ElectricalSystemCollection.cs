using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystemCollection : SystemCollection<ElectricalSystem>
    {
        private ElectricalSystemCollectionType electricalSystemCollectionType = ElectricalSystemCollectionType.None;

        public ElectricalSystemCollection()
            : base()
        {
        }

        public ElectricalSystemCollection(string name, ElectricalSystemCollectionType electricalSystemCollectionType)
            : base(name)
        {
            this.electricalSystemCollectionType = electricalSystemCollectionType;
        }

        public ElectricalSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public ElectricalSystemCollection(ElectricalSystemCollection electricalSystemCollection)
            : base(electricalSystemCollection)
        {
            if(electricalSystemCollection != null)
            {
                electricalSystemCollectionType = electricalSystemCollection.electricalSystemCollectionType;
            }
        }

        public ElectricalSystemCollection(System.Guid guid, ElectricalSystemCollection electricalSystemCollection)
            : base(guid, electricalSystemCollection)
        {
            if (electricalSystemCollection != null)
            {
                electricalSystemCollectionType = electricalSystemCollection.electricalSystemCollectionType;
            }
        }

        public ElectricalSystemCollectionType ElectricalSystemCollectionType
        {
            get
            {
                return electricalSystemCollectionType;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("ElectricalSystemCollectionType"))
            {
                electricalSystemCollectionType = Core.Query.Enum<ElectricalSystemCollectionType>(jObject.Value<string>("ElectricalSystemCollectionType"));
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

            result.Add("ElectricalSystemCollectionType", electricalSystemCollectionType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new ElectricalSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}

