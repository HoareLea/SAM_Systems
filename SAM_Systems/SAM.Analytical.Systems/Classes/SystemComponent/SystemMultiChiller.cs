using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChiller : SystemChiller
    {
        public double DesignPressureDrop { get; set; }
        public double DesignTemperatureDiffrence { get; set; }

        public SystemMultiChiller(string name)
            : base(name)
        {

        }

        public SystemMultiChiller(SystemMultiChiller systemMultiChiller)
            : base(systemMultiChiller)
        {
            if (systemMultiChiller != null)
            {
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

            return result;
        }
    }
}


