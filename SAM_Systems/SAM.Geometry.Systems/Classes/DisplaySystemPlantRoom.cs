using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemPlantRoom : SystemPlantRoom
    {
        public DisplaySystemPlantRoom(DisplaySystemPlantRoom displaySystemPlantRoom)
            :base(displaySystemPlantRoom)
        {

        }

        public DisplaySystemPlantRoom(JObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemPlantRoom(string name)
            : base(name)
        {

        }

        protected override ISystemConnection CreateSystemConnection(ISystemComponent systemComponent_1, ISystemComponent systemComponent_2, ISystem system = null, int index_1 = -1, int index_2 = -1)
        {
            if(systemComponent_1 == null || systemComponent_2 == null)
            {
                return null;
            }

            if(!(systemComponent_1 is IDisplayObject) || !(systemComponent_2 is IDisplayObject))
            {
                return base.CreateSystemConnection(systemComponent_1, systemComponent_2, system, index_1, index_2);
            }

            throw new System.NotImplementedException();
        }
    }
}
