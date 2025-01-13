using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChiller : SystemMultiComponent<SystemMultiChillerItem>
    {
        public double DesignPressureDrop { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public SizableValue Duty { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public double Capacity { get; set; }
        public EquipmentSequence Sequence { get; set; }

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
                DesignTemperatureDifference = systemMultiChiller.DesignTemperatureDifference;
                Setpoint = systemMultiChiller.Setpoint?.Clone();
                Capacity = systemMultiChiller.Capacity;
                Sequence = systemMultiChiller.Sequence;
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
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

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject.Value<double>("DesignTemperatureDifference");
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("Sequence"))
            {
                Sequence = Core.Query.Enum<EquipmentSequence>(jObject.Value<string>("Sequence"));
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

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            result.Add("Sequence", Sequence.ToString());

            return result;
        }
    }
}


