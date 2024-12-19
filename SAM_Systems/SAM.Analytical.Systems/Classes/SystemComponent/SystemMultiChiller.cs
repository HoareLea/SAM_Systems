using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChiller : SystemMultiComponent<SystemMultiChillerItem>
    {
        public double DesignPressureDrop { get; set; }
        public double DesignTemperatureDiffrence { get; set; }
        public SizableValue Duty { get; set; }

        public SystemMultiChiller(string name)
            : base(name)
        {

        }

        public SystemMultiChiller(SystemMultiChiller systemMultiChiller)
            : base(systemMultiChiller)
        {
            if (systemMultiChiller != null)
            {
                Duty = systemMultiChiller.Duty?.Clone();
                DesignPressureDrop = systemMultiChiller.DesignPressureDrop;
                DesignTemperatureDiffrence = systemMultiChiller.DesignTemperatureDiffrence;
            }
        }

        public SystemMultiChiller(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
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

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("DesignTemperatureDiffrence"))
            {
                DesignTemperatureDiffrence = jObject.Value<double>("DesignTemperatureDiffrence");
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
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

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(DesignTemperatureDiffrence))
            {
                result.Add("DesignTemperatureDiffrence", DesignTemperatureDiffrence);
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            return result;
        }
    }
}


