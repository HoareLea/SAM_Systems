using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMultiBoiler : SystemMultiComponent<SystemMultiBoilerItem>, ILiquidSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ISizableValue Duty { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public double DesignPressureDrop { get; set; }
        public double Capacity { get; set; }
        public bool LossesInSizing { get; set; }
        public EquipmentSequence Sequence { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public string ScheduleName { get; set; }

        public SystemMultiBoiler(string name)
            : base(name)
        {

        }

        public SystemMultiBoiler(SystemMultiBoiler systemMultiBoiler)
            : base(systemMultiBoiler)
        {
            if(systemMultiBoiler != null)
            {
                Setpoint = systemMultiBoiler.Setpoint?.Clone();
                Duty = systemMultiBoiler.Duty.Clone();
                DesignTemperatureDifference = systemMultiBoiler.DesignTemperatureDifference;
                DesignPressureDrop = systemMultiBoiler.DesignPressureDrop;
                LossesInSizing = systemMultiBoiler.LossesInSizing;
                Sequence = systemMultiBoiler.Sequence;
                IsDomesticHotWater = systemMultiBoiler.IsDomesticHotWater;
                Capacity = systemMultiBoiler.Capacity;
                ScheduleName = systemMultiBoiler.ScheduleName;
            }
        }

        public SystemMultiBoiler(System.Guid guid, SystemMultiBoiler systemMultiBoiler)
            : base(guid, systemMultiBoiler)
        {
            if (systemMultiBoiler != null)
            {
                Setpoint = systemMultiBoiler.Setpoint?.Clone();
                Duty = systemMultiBoiler.Duty.Clone();
                DesignTemperatureDifference = systemMultiBoiler.DesignTemperatureDifference;
                DesignPressureDrop = systemMultiBoiler.DesignPressureDrop;
                LossesInSizing = systemMultiBoiler.LossesInSizing;
                Sequence = systemMultiBoiler.Sequence;
                IsDomesticHotWater = systemMultiBoiler.IsDomesticHotWater;
                Capacity = systemMultiBoiler.Capacity;
                ScheduleName = systemMultiBoiler.ScheduleName;
            }
        }

        public SystemMultiBoiler(JObject jObject)
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

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject.Value<double>("DesignTemperatureDifference");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject.Value<bool>("LossesInSizing");
            }

            if (jObject.ContainsKey("Sequence"))
            {
                Sequence = Core.Query.Enum<EquipmentSequence>(jObject.Value<string>("Sequence"));
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("IsDomesticHotWater"))
            {
                IsDomesticHotWater = jObject.Value<bool>("IsDomesticHotWater");
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
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

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            result.Add("LossesInSizing", LossesInSizing);

            result.Add("IsDomesticHotWater", IsDomesticHotWater);

            result.Add("Sequence", Sequence.ToString());

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMultiBoiler(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}


