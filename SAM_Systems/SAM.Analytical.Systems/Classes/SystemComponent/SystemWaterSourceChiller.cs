// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

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

        public string ScheduleName { get; set; }

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
                ScheduleName = waterSourceSystemChiller.ScheduleName;
            }
        }

        public SystemWaterSourceChiller(System.Guid guid, SystemWaterSourceChiller waterSourceSystemChiller)
            : base(guid, waterSourceSystemChiller)
        {
            if (waterSourceSystemChiller != null)
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
                ScheduleName = waterSourceSystemChiller.ScheduleName;
            }
        }

        public SystemWaterSourceChiller(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("Capacity1"))
            {
                Capacity1 = jObject["Capacity1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject["DesignPressureDrop1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference1"))
            {
                DesignTemperatureDifference1 = jObject["DesignTemperatureDifference1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity2"))
            {
                Capacity2 = jObject["Capacity2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject["DesignPressureDrop2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference2"))
            {
                DesignTemperatureDifference2 = jObject["DesignTemperatureDifference2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject["LossesInSizing"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["MotorEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("ExchangerCalculationMethod"))
            {
                ExchangerCalculationMethod = Core.Query.Enum<ExchangerCalculationMethod>(jObject["ExchangerCalculationMethod"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ExchangerEfficiency"))
            {
                ExchangerEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["ExchangerEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("ExchangerType"))
            {
                ExchangerType = Core.Query.Enum<ExchangerType>(jObject["ExchangerType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = jObject["HeatTransferSurfaceArea"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("HeatTransferCoefficient"))
            {
                HeatTransferCoefficient = jObject["HeatTransferCoefficient"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("FreeCoolingType"))
            {
                FreeCoolingType = Core.Query.Enum<FreeCoolingType>(jObject["FreeCoolingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if(Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
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
                result.Add("MotorEfficiency", MotorEfficiency.ToJsonObject());
            }

            result.Add("ExchangerCalculationMethod", ExchangerCalculationMethod.ToString());

            if (ExchangerEfficiency != null)
            {
                result.Add("ExchangerEfficiency", ExchangerEfficiency.ToJsonObject());
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
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            result.Add("FreeCoolingType", FreeCoolingType.ToString());

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemWaterSourceChiller(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}