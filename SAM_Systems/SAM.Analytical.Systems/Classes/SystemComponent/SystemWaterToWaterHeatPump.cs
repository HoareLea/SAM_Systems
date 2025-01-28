using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemWaterToWaterHeatPump : SystemHeatPump
    {
        public ModifiableValue HeatingSetpoint { get; set; }
        public ModifiableValue CoolingSetpoint { get; set; }
        public ModifiableValue HeatingEfficiency { get; set; }
        public ModifiableValue CoolingEfficiency { get; set; }
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public double Capacity1 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double DesignTemperatureDifference1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double DesignTemperatureDifference2 { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool LossesInSizing { get; set; }
        public bool IsDomesticHotWater { get; set; }

        public SystemWaterToWaterHeatPump(string name)
            : base(name)
        {

        }

        public SystemWaterToWaterHeatPump(SystemWaterToWaterHeatPump systemWaterToWaterHeatPump)
            : base(systemWaterToWaterHeatPump)
        {
            if(systemWaterToWaterHeatPump != null)
            {
                HeatingSetpoint = systemWaterToWaterHeatPump.HeatingSetpoint?.Clone();
                CoolingSetpoint = systemWaterToWaterHeatPump.CoolingSetpoint?.Clone();
                HeatingEfficiency = systemWaterToWaterHeatPump.HeatingEfficiency?.Clone();
                CoolingEfficiency = systemWaterToWaterHeatPump.CoolingEfficiency?.Clone();
                HeatingDuty = systemWaterToWaterHeatPump.HeatingDuty?.Clone();
                CoolingDuty = systemWaterToWaterHeatPump.CoolingDuty?.Clone();
                Capacity1 = systemWaterToWaterHeatPump.Capacity1;
                DesignPressureDrop1 = systemWaterToWaterHeatPump.DesignPressureDrop1;
                DesignTemperatureDifference1 = systemWaterToWaterHeatPump.DesignTemperatureDifference1;
                Capacity2 = systemWaterToWaterHeatPump.Capacity2;
                DesignPressureDrop2 = systemWaterToWaterHeatPump.DesignPressureDrop2;
                DesignTemperatureDifference2 = systemWaterToWaterHeatPump.DesignTemperatureDifference2;
                MotorEfficiency = systemWaterToWaterHeatPump.MotorEfficiency?.Clone();
                AncillaryLoad = systemWaterToWaterHeatPump.AncillaryLoad?.Clone();
                LossesInSizing = systemWaterToWaterHeatPump.LossesInSizing;
                IsDomesticHotWater = systemWaterToWaterHeatPump.IsDomesticHotWater;
            }
        }

        public SystemWaterToWaterHeatPump(JObject jObject)
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
                    Core.Systems.Create.SystemConnector<IControlSystem>(),
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

            if (jObject.ContainsKey("HeatingSetpoint"))
            {
                HeatingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingSetpoint"));
            }

            if (jObject.ContainsKey("CoolingSetpoint"))
            {
                CoolingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CoolingSetpoint"));
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingEfficiency"));
            }

            if (jObject.ContainsKey("CoolingEfficiency"))
            {
                CoolingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CoolingEfficiency"));
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatingDuty"));
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("CoolingDuty"));
            }

            if (jObject.ContainsKey("Capacity1"))
            {
                Capacity1 = jObject.Value<double>("Capacity1");
            }

            if (jObject.ContainsKey("Capacity2"))
            {
                Capacity2 = jObject.Value<double>("Capacity2");
            }

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject.Value<double>("DesignPressureDrop1");
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject.Value<double>("DesignPressureDrop2");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference1"))
            {
                DesignTemperatureDifference1 = jObject.Value<double>("DesignTemperatureDifference1");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference2"))
            {
                DesignTemperatureDifference2 = jObject.Value<double>("DesignTemperatureDifference2");
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MotorEfficiency"));
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject.Value<bool>("LossesInSizing");
            }

            if (jObject.ContainsKey("IsDomesticHotWater"))
            {
                IsDomesticHotWater = jObject.Value<bool>("IsDomesticHotWater");
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

            if (HeatingSetpoint != null)
            {
                result.Add("HeatingSetpoint", HeatingSetpoint.ToJObject());
            }

            if (CoolingSetpoint != null)
            {
                result.Add("CoolingSetpoint", CoolingSetpoint.ToJObject());
            }

            if (HeatingEfficiency != null)
            {
                result.Add("HeatingEfficiency", HeatingEfficiency.ToJObject());
            }

            if (CoolingEfficiency != null)
            {
                result.Add("CoolingEfficiency", CoolingEfficiency.ToJObject());
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJObject());
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

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJObject());
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            result.Add("LossesInSizing", LossesInSizing);

            result.Add("IsDomesticHotWater", IsDomesticHotWater);

            return result;
        }
    }
}