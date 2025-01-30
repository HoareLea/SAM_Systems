using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemLoadComponent : SystemComponent
    {
        public ModifiableValue Load { get; set; }


        public SystemLoadComponent(string name)
            : base(name)
        {

        }

        public SystemLoadComponent(SystemLoadComponent systemLoadComponent)
            : base(systemLoadComponent)
        {
            if(systemLoadComponent != null)
            {
                Load = systemLoadComponent.Load?.Clone();
            }
        }

        public SystemLoadComponent(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    //Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Load"))
            {
                Load = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Load"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }
            
            if (Load != null)
            {
                result.Add("Load", Load.ToJObject());
            }

            return result;
        }
    }
}