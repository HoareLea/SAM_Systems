using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystemGroup : SystemGroup<ElectricalSystem>
    {
        private ElectricalGroupType electricalGroupType;

        public ElectricalSystemGroup()
            : base()
        {
        }

        public ElectricalSystemGroup(string name, ElectricalGroupType electricalGroupType)
            : base(name)
        {
            this.electricalGroupType = electricalGroupType; 
        }

        public ElectricalSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public ElectricalSystemGroup(ElectricalSystemGroup electricalSystemGroup)
            : base(electricalSystemGroup)
        {
            if(electricalSystemGroup != null)
            {
                electricalGroupType = electricalSystemGroup.electricalGroupType;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("ElectricalGroupType"))
            {
                electricalGroupType = Core.Query.Enum<ElectricalGroupType>(jObject.Value<string>("ElectricalGroupType"));
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

            result.Add("ElectricalGroupType", electricalGroupType.ToString());

            return result;
        }
    }
}
