// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
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
        /// <summary>
        /// Exchange Demand Factor for heating mode
        /// </summary>
        public double ADFHeatingMode { get; set; }
        /// <summary>
        /// Exchange Demand Factor for cooling mode
        /// </summary>
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

        public SystemFourPipeHeatPump(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("HeatingSetpoint"))
            {
                HeatingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingSetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingSetpoint"))
            {
                CoolingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["CoolingSetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingEfficiency"))
            {
                CoolingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["CoolingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<ISizableValue>(jObject["HeatingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<ISizableValue>(jObject["CoolingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignPressureDrop_1"))
            {
                DesignPressureDrop_1 = jObject["DesignPressureDrop_1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity_1"))
            {
                Capacity_1 = jObject["Capacity_1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference_1"))
            {
                DesignTemperatureDifference_1 = jObject["DesignTemperatureDifference_1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop_2"))
            {
                DesignPressureDrop_2 = jObject["DesignPressureDrop_2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity_2"))
            {
                Capacity_2 = jObject["Capacity_2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference_2"))
            {
                DesignTemperatureDifference_2 = jObject["DesignTemperatureDifference_2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["MotorEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("ADFHeatingMode"))
            {
                ADFHeatingMode = jObject["ADFHeatingMode"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("ADFCoolingMode"))
            {
                ADFCoolingMode = jObject["ADFCoolingMode"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return result;
            }

            if (HeatingSetpoint != null)
            {
                result.Add("HeatingSetpoint", HeatingSetpoint.ToJsonObject());
            }

            if (CoolingSetpoint != null)
            {
                result.Add("CoolingSetpoint", CoolingSetpoint.ToJsonObject());
            }

            if (HeatingEfficiency != null)
            {
                result.Add("HeatingEfficiency", HeatingEfficiency.ToJsonObject());
            }

            if (CoolingEfficiency != null)
            {
                result.Add("CoolingEfficiency", CoolingEfficiency.ToJsonObject());
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJsonObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJsonObject());
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
                result.Add("MotorEfficiency", MotorEfficiency.ToJsonObject());
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
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