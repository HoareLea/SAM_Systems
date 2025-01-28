using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemIceStorageChiller : SystemChiller
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue IceMakingEfficiency { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public ISizableValue IceCapacity { get; set; }
        public double InitialIceReserve { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public double IceMeltChillerFraction { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool LossesInSizing { get; set; }

        public SystemIceStorageChiller(string name)
            : base(name)
        {

        }

        public SystemIceStorageChiller(SystemIceStorageChiller iceStorageSystemChiller)
            : base(iceStorageSystemChiller)
        {
            if (iceStorageSystemChiller != null)
            {
                Setpoint = iceStorageSystemChiller.Setpoint?.Clone();
                Efficiency = iceStorageSystemChiller.Efficiency?.Clone();
                IceMakingEfficiency = iceStorageSystemChiller.IceMakingEfficiency?.Clone();
                Capacity = iceStorageSystemChiller.Capacity;
                DesignPressureDrop = iceStorageSystemChiller.DesignPressureDrop;
                DesignTemperatureDifference = iceStorageSystemChiller.DesignTemperatureDifference;
                IceCapacity = iceStorageSystemChiller.IceCapacity?.Clone();
                InitialIceReserve = iceStorageSystemChiller.InitialIceReserve;
                CondenserFanLoad = iceStorageSystemChiller.CondenserFanLoad?.Clone();
                MotorEfficiency = iceStorageSystemChiller.MotorEfficiency?.Clone();
                IceMeltChillerFraction = iceStorageSystemChiller.IceMeltChillerFraction;
                AncillaryLoad = iceStorageSystemChiller.AncillaryLoad?.Clone();
                LossesInSizing = iceStorageSystemChiller.LossesInSizing;
            }
        }

        public SystemIceStorageChiller(JObject jObject)
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

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("IceMakingEfficiency"))
            {
                IceMakingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("IceMakingEfficiency"));
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject.Value<double>("DesignTemperatureDifference");
            }

            if (jObject.ContainsKey("IceCapacity"))
            {
                IceCapacity = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("IceCapacity"));
            }

            if (jObject.ContainsKey("InitialIceReserve"))
            {
                InitialIceReserve = jObject.Value<double>("InitialIceReserve");
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CondenserFanLoad"));
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MotorEfficiency"));
            }

            if (jObject.ContainsKey("IceMeltChillerFraction"))
            {
                IceMeltChillerFraction = jObject.Value<double>("IceMeltChillerFraction");
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject.Value<bool>("LossesInSizing");
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

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (IceMakingEfficiency != null)
            {
                result.Add("IceMakingEfficiency", IceMakingEfficiency.ToJObject());
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (IceCapacity != null)
            {
                result.Add("IceCapacity", IceCapacity.ToJObject());
            }

            if (!double.IsNaN(InitialIceReserve))
            {
                result.Add("InitialIceReserve", InitialIceReserve);
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJObject());
            }

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJObject());
            }

            if (!double.IsNaN(IceMeltChillerFraction))
            {
                result.Add("IceMeltChillerFraction", IceMeltChillerFraction);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            result.Add("LossesInSizing", LossesInSizing);

            return result;
        }
    }
}



