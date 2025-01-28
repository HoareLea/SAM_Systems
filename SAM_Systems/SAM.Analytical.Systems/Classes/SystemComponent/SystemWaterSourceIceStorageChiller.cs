using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceIceStorageChiller : SystemChiller
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue IceMakingEfficiency { get; set; }
        public double Capacity1 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double DesignTemperatureDifference1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double DesignTemperatureDifference2 { get; set; }
        public ISizableValue IceCapacity { get; set; }
        public double InitialIceReserve { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public double IceMeltChillerFraction { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool LossesInSizing { get; set; }

        public SystemWaterSourceIceStorageChiller(string name)
            : base(name)
        {

        }

        public SystemWaterSourceIceStorageChiller(SystemWaterSourceIceStorageChiller waterSourceIceStorageSystemChiller)
            : base(waterSourceIceStorageSystemChiller)
        {
            if (waterSourceIceStorageSystemChiller != null)
            {
                Setpoint = waterSourceIceStorageSystemChiller.Setpoint?.Clone();
                Efficiency = waterSourceIceStorageSystemChiller.Efficiency?.Clone();
                IceMakingEfficiency = waterSourceIceStorageSystemChiller.IceMakingEfficiency?.Clone();
                Capacity1 = waterSourceIceStorageSystemChiller.Capacity1;
                DesignPressureDrop1 = waterSourceIceStorageSystemChiller.DesignPressureDrop1;
                DesignTemperatureDifference1 = waterSourceIceStorageSystemChiller.DesignTemperatureDifference1;
                Capacity2 = waterSourceIceStorageSystemChiller.Capacity2;
                DesignPressureDrop2 = waterSourceIceStorageSystemChiller.DesignPressureDrop2;
                DesignTemperatureDifference2 = waterSourceIceStorageSystemChiller.DesignTemperatureDifference2;
                IceCapacity = waterSourceIceStorageSystemChiller.IceCapacity?.Clone();
                InitialIceReserve = waterSourceIceStorageSystemChiller.InitialIceReserve;
                CondenserFanLoad = waterSourceIceStorageSystemChiller.CondenserFanLoad?.Clone();
                MotorEfficiency = waterSourceIceStorageSystemChiller.MotorEfficiency?.Clone();
                IceMeltChillerFraction = waterSourceIceStorageSystemChiller.IceMeltChillerFraction;
                AncillaryLoad = waterSourceIceStorageSystemChiller.AncillaryLoad?.Clone();
                LossesInSizing = waterSourceIceStorageSystemChiller.LossesInSizing;
            }
        }

        public SystemWaterSourceIceStorageChiller(JObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 2),
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

            if (jObject.ContainsKey("Capacity1"))
            {
                Capacity1 = jObject.Value<double>("Capacity1");
            }

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject.Value<double>("DesignPressureDrop1");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference1"))
            {
                DesignTemperatureDifference1 = jObject.Value<double>("DesignTemperatureDifference1");
            }

            if (jObject.ContainsKey("Capacity2"))
            {
                Capacity2 = jObject.Value<double>("Capacity2");
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject.Value<double>("DesignPressureDrop2");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference2"))
            {
                DesignTemperatureDifference2 = jObject.Value<double>("DesignTemperatureDifference2");
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

            if (!double.IsNaN(Capacity1))
            {
                result.Add("Capacity1", Capacity1);
            }

            if (!double.IsNaN(DesignPressureDrop1))
            {
                result.Add("DesignPressureDrop1", DesignPressureDrop1);
            }

            if (!double.IsNaN(DesignTemperatureDifference1))
            {
                result.Add("DesignTemperatureDifference1", DesignTemperatureDifference1);
            }

            if (!double.IsNaN(Capacity2))
            {
                result.Add("Capacity2", Capacity2);
            }

            if (!double.IsNaN(DesignPressureDrop2))
            {
                result.Add("DesignPressureDrop2", DesignPressureDrop2);
            }

            if (!double.IsNaN(DesignTemperatureDifference2))
            {
                result.Add("DesignTemperatureDifference2", DesignTemperatureDifference2);
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



