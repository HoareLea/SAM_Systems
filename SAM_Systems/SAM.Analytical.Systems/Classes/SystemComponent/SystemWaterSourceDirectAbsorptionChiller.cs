using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceDirectAbsorptionChiller : SystemChiller
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public double Capacity1 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double DesignTemperatureDifference1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double DesignTemperatureDifference2 { get; set; }
        public bool LossesInSizing { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public ExchangerCalculationMethod ExchangerCalculationMethod { get; set; }
        public ModifiableValue ExchangerEfficiency { get; set; }
        public ExchangerType ExchangerType { get; set; }
        public double HeatTransferSurfaceArea { get; set; }
        public double HeatTransferCoefficient { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public FreeCoolingType FreeCoolingType { get; set; }

        public string ScheduleName { get; set; }

        public SystemWaterSourceDirectAbsorptionChiller(string name)
            : base(name)
        {

        }

        public SystemWaterSourceDirectAbsorptionChiller(SystemWaterSourceDirectAbsorptionChiller waterSourceDirectAbsorptionSystemChiller)
            : base(waterSourceDirectAbsorptionSystemChiller)
        {
            if (waterSourceDirectAbsorptionSystemChiller != null)
            {
                Setpoint = waterSourceDirectAbsorptionSystemChiller.Setpoint?.Clone();
                Efficiency = waterSourceDirectAbsorptionSystemChiller.Efficiency?.Clone();
                Capacity1 = waterSourceDirectAbsorptionSystemChiller.Capacity1;
                DesignPressureDrop1 = waterSourceDirectAbsorptionSystemChiller.DesignPressureDrop1;
                DesignTemperatureDifference1 = waterSourceDirectAbsorptionSystemChiller.DesignTemperatureDifference1;
                Capacity2 = waterSourceDirectAbsorptionSystemChiller.Capacity2;
                DesignPressureDrop2 = waterSourceDirectAbsorptionSystemChiller.DesignPressureDrop2;
                DesignTemperatureDifference2 = waterSourceDirectAbsorptionSystemChiller.DesignTemperatureDifference2;
                LossesInSizing = waterSourceDirectAbsorptionSystemChiller.LossesInSizing;
                MotorEfficiency = waterSourceDirectAbsorptionSystemChiller.MotorEfficiency?.Clone();
                ExchangerCalculationMethod = waterSourceDirectAbsorptionSystemChiller.ExchangerCalculationMethod;
                ExchangerEfficiency = waterSourceDirectAbsorptionSystemChiller.ExchangerEfficiency?.Clone();
                ExchangerType = waterSourceDirectAbsorptionSystemChiller.ExchangerType;
                HeatTransferSurfaceArea = waterSourceDirectAbsorptionSystemChiller.HeatTransferSurfaceArea;
                HeatTransferCoefficient = waterSourceDirectAbsorptionSystemChiller.HeatTransferCoefficient;
                AncillaryLoad = waterSourceDirectAbsorptionSystemChiller.AncillaryLoad?.Clone();
                FreeCoolingType = waterSourceDirectAbsorptionSystemChiller.FreeCoolingType;
                ScheduleName = waterSourceDirectAbsorptionSystemChiller.ScheduleName;
            }
        }

        public SystemWaterSourceDirectAbsorptionChiller(JObject jObject)
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

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject.Value<bool>("LossesInSizing");
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MotorEfficiency"));
            }

            if (jObject.ContainsKey("ExchangerCalculationMethod"))
            {
                ExchangerCalculationMethod = Core.Query.Enum<ExchangerCalculationMethod>(jObject.Value<string>("ExchangerCalculationMethod"));
            }

            if (jObject.ContainsKey("ExchangerEfficiency"))
            {
                ExchangerEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ExchangerEfficiency"));
            }

            if (jObject.ContainsKey("ExchangerType"))
            {
                ExchangerType = Core.Query.Enum<ExchangerType>(jObject.Value<string>("ExchangerType"));
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = jObject.Value<double>("HeatTransferSurfaceArea");
            }

            if (jObject.ContainsKey("HeatTransferCoefficient"))
            {
                HeatTransferCoefficient = jObject.Value<double>("HeatTransferCoefficient");
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("FreeCoolingType"))
            {
                FreeCoolingType = Core.Query.Enum<FreeCoolingType>(jObject.Value<string>("FreeCoolingType"));
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
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

            result.Add("LossesInSizing", LossesInSizing);

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJObject());
            }

            result.Add("ExchangerCalculationMethod", ExchangerCalculationMethod.ToString());

            if (ExchangerEfficiency != null)
            {
                result.Add("ExchangerEfficiency", ExchangerEfficiency.ToJObject());
            }

            result.Add("ExchangerType", ExchangerType.ToString());

            if (!double.IsNaN(HeatTransferSurfaceArea))
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea);
            }

            if (!double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            result.Add("FreeCoolingType", FreeCoolingType.ToString());

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}