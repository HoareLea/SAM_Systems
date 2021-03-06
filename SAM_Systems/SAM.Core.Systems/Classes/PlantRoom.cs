using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class PlantRoom : SAMObject
    {

        public PlantRoom(PlantRoom plantRoom)
            :base(plantRoom)
        {

        }

        public PlantRoom(JObject jObject)
            : base(jObject)
        {

        }

        public PlantRoom(string name)
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
