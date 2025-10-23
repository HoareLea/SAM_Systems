using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemFourPipeHeatPump : SystemHeatPump
    {
        public ModifiableValue HeatingSetpoint { get; set; }
        public ModifiableValue CoolingSetpoint { get; set; }
        public ModifiableValue HeatingEfficiency { get; set; }
        public ModifiableValue CoolingEfficiency { get; set; }
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public double DesignPressureDrop_1 { get; set; }
        public double Capacity_1 { get; set; }
        public double DesignTemperatureDifference_1 { get; set; }
        public double DesignPressureDrop_2 { get; set; }
        public double Capacity_2 { get; set; }
        public double DesignTemperatureDifference_2 { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public double ADFHeatingMode { get; set; }
        public double ADFCoolingMode { get; set; }

        public SystemFourPipeHeatPump(string name)
            : base(name)
        {

        }

        public SystemFourPipeHeatPump(SystemFourPipeHeatPump systemFourPipeHeatPump)
            : base(systemFourPipeHeatPump)
        {
            if (systemFourPipeHeatPump != null)
            {
                HeatingSetpoint = systemFourPipeHeatPump.HeatingSetpoint?.Clone();
                CoolingSetpoint = systemFourPipeHeatPump.CoolingSetpoint?.Clone();
                HeatingEfficiency = systemFourPipeHeatPump.HeatingEfficiency?.Clone();
                CoolingEfficiency = systemFourPipeHeatPump.CoolingEfficiency?.Clone();
                HeatingDuty = systemFourPipeHeatPump.HeatingDuty?.Clone();
                CoolingDuty = systemFourPipeHeatPump.CoolingDuty?.Clone();

                DesignPressureDrop_1 = systemFourPipeHeatPump.DesignPressureDrop_1;
                Capacity_1 = systemFourPipeHeatPump.Capacity_1;
                DesignTemperatureDifference_1 = systemFourPipeHeatPump.DesignTemperatureDifference_1;
                DesignPressureDrop_2 = systemFourPipeHeatPump.DesignPressureDrop_2;
                Capacity_2 = systemFourPipeHeatPump.Capacity_2;
                DesignTemperatureDifference_2 = systemFourPipeHeatPump.DesignTemperatureDifference_2;

                MotorEfficiency = systemFourPipeHeatPump.MotorEfficiency?.Clone();
                AncillaryLoad = systemFourPipeHeatPump.AncillaryLoad?.Clone();

                ADFHeatingMode = systemFourPipeHeatPump.ADFHeatingMode;
                ADFCoolingMode = systemFourPipeHeatPump.ADFCoolingMode;
            }
        }

        public SystemFourPipeHeatPump(Guid guid, SystemFourPipeHeatPump systemFourPipeHeatPump)
            : base(guid, systemFourPipeHeatPump)
        {
            if (systemFourPipeHeatPump != null)
            {
                HeatingSetpoint = systemFourPipeHeatPump.HeatingSetpoint?.Clone();
                CoolingSetpoint = systemFourPipeHeatPump.CoolingSetpoint?.Clone();
                HeatingEfficiency = systemFourPipeHeatPump.HeatingEfficiency?.Clone();
                CoolingEfficiency = systemFourPipeHeatPump.CoolingEfficiency?.Clone();
                HeatingDuty = systemFourPipeHeatPump.HeatingDuty?.Clone();
                CoolingDuty = systemFourPipeHeatPump.CoolingDuty?.Clone();

                DesignPressureDrop_1 = systemFourPipeHeatPump.DesignPressureDrop_1;
                Capacity_1 = systemFourPipeHeatPump.Capacity_1;
                DesignTemperatureDifference_1 = systemFourPipeHeatPump.DesignTemperatureDifference_1;
                DesignPressureDrop_2 = systemFourPipeHeatPump.DesignPressureDrop_2;
                Capacity_2 = systemFourPipeHeatPump.Capacity_2;
                DesignTemperatureDifference_2 = systemFourPipeHeatPump.DesignTemperatureDifference_2;

                MotorEfficiency = systemFourPipeHeatPump.MotorEfficiency?.Clone();
                AncillaryLoad = systemFourPipeHeatPump.AncillaryLoad?.Clone();

                ADFHeatingMode = systemFourPipeHeatPump.ADFHeatingMode;
                ADFCoolingMode = systemFourPipeHeatPump.ADFCoolingMode;
            }
        }

        public SystemFourPipeHeatPump(JObject jObject)
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
                HeatingDuty = Core.Query.IJSAMObject<ISizableValue>(jObject.Value<JObject>("HeatingDuty"));
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<ISizableValue>(jObject.Value<JObject>("CoolingDuty"));
            }

            if (jObject.ContainsKey("DesignPressureDrop_1"))
            {
                DesignPressureDrop_1 = jObject.Value<double>("DesignPressureDrop_1");
            }

            if (jObject.ContainsKey("Capacity_1"))
            {
                Capacity_1 = jObject.Value<double>("Capacity_1");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference_1"))
            {
                DesignTemperatureDifference_1 = jObject.Value<double>("DesignTemperatureDifference_1");
            }

            if (jObject.ContainsKey("DesignPressureDrop_2"))
            {
                DesignPressureDrop_2 = jObject.Value<double>("DesignPressureDrop_2");
            }

            if (jObject.ContainsKey("Capacity_2"))
            {
                Capacity_2 = jObject.Value<double>("Capacity_2");
            }

            if (jObject.ContainsKey("DesignTemperatureDifference_2"))
            {
                DesignTemperatureDifference_2 = jObject.Value<double>("DesignTemperatureDifference_2");
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MotorEfficiency"));
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
            }

            if (jObject.ContainsKey("ADFHeatingMode"))
            {
                ADFHeatingMode = jObject.Value<double>("ADFHeatingMode");
            }

            if (jObject.ContainsKey("ADFCoolingMode"))
            {
                ADFCoolingMode = jObject.Value<double>("ADFCoolingMode");
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

            if (!double.IsNaN(DesignPressureDrop_1))
            {
                result.Add("DesignPressureDrop_1", DesignPressureDrop_1);
            }

            if (!double.IsNaN(Capacity_1))
            {
                result.Add("Capacity_1", Capacity_1);
            }

            if (!double.IsNaN(DesignTemperatureDifference_1))
            {
                result.Add("DesignTemperatureDifference_1", DesignTemperatureDifference_1);
            }

            if (!double.IsNaN(DesignPressureDrop_2))
            {
                result.Add("DesignPressureDrop_2", DesignPressureDrop_2);
            }

            if (!double.IsNaN(Capacity_2))
            {
                result.Add("Capacity_2", Capacity_2);
            }

            if (!double.IsNaN(DesignTemperatureDifference_2))
            {
                result.Add("DesignTemperatureDifference_2", DesignTemperatureDifference_2);
            }

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJObject());
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            if (!double.IsNaN(ADFHeatingMode))
            {
                result.Add("ADFHeatingMode", ADFHeatingMode);
            }

            if (!double.IsNaN(ADFCoolingMode))
            {
                result.Add("ADFCoolingMode", ADFCoolingMode);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemFourPipeHeatPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}