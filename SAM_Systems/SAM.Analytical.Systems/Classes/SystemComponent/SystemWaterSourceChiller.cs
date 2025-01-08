using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceChiller : SystemChiller
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

        public SystemWaterSourceChiller(string name)
            : base(name)
        {

        }

        public SystemWaterSourceChiller(SystemWaterSourceChiller waterSourceSystemChiller)
            : base(waterSourceSystemChiller)
        {
            if(waterSourceSystemChiller != null)
            {
                Setpoint = waterSourceSystemChiller.Setpoint?.Clone();
                Efficiency = waterSourceSystemChiller.Efficiency?.Clone();
                Capacity1 = waterSourceSystemChiller.Capacity1;
                DesignPressureDrop1 = waterSourceSystemChiller.DesignPressureDrop1;
                DesignTemperatureDifference1 = waterSourceSystemChiller.DesignTemperatureDifference1;
                Capacity2 = waterSourceSystemChiller.Capacity2;
                DesignPressureDrop2 = waterSourceSystemChiller.DesignPressureDrop2;
                DesignTemperatureDifference2 = waterSourceSystemChiller.DesignTemperatureDifference2;
                LossesInSizing = waterSourceSystemChiller.LossesInSizing;
                MotorEfficiency = waterSourceSystemChiller.MotorEfficiency?.Clone();
                ExchangerCalculationMethod = waterSourceSystemChiller.ExchangerCalculationMethod;
                ExchangerEfficiency = waterSourceSystemChiller.ExchangerEfficiency?.Clone();
                ExchangerType = waterSourceSystemChiller.ExchangerType;
                HeatTransferSurfaceArea = waterSourceSystemChiller.HeatTransferSurfaceArea;
                HeatTransferCoefficient = waterSourceSystemChiller.HeatTransferCoefficient;
                AncillaryLoad = waterSourceSystemChiller.AncillaryLoad?.Clone();
                FreeCoolingType = waterSourceSystemChiller.FreeCoolingType;
            }
        }

        public SystemWaterSourceChiller(JObject jObject)
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

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(Setpoint != null)
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

            return result;
        }
    }
}