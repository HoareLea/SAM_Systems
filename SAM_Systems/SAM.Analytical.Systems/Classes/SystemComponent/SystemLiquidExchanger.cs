// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Heat Exchanger (Liquid Side)
    /// </summary>
    public class SystemLiquidExchanger : SystemComponent, ILiquidSystemComponent
    {
        public ModifiableValue Efficiency { get; set; }
        public double Capacity1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public ModifiableValue Setpoint { get; set; }
        //public ModifiableValue Setpoint2 { get; set; }
        public ExchangerPosition BypassPosition { get; set; }
        public ExchangerPosition SetpointPosition { get; set; }
        public ExchangerCalculationMethod ExchangerCalculationMethod { get; set; }
        public ExchangerType ExchangerType { get; set; }
        public double HeatTransferSurfaceArea { get; set; }
        public double HeatTransferCoefficient { get; set; }

        public string ScheduleName { get; set; }

        public SystemLiquidExchanger(string name)
            : base(name)
        {

        }

        public SystemLiquidExchanger(System.Guid guid, SystemLiquidExchanger systemLiquidExchanger)
            : base(guid, systemLiquidExchanger)
        {
            if (systemLiquidExchanger != null)
            {
                Efficiency = systemLiquidExchanger.Efficiency?.Clone();

                Capacity1 = systemLiquidExchanger.Capacity1;
                Capacity2 = systemLiquidExchanger.Capacity2;

                DesignPressureDrop1 = systemLiquidExchanger.DesignPressureDrop1;
                DesignPressureDrop2 = systemLiquidExchanger.DesignPressureDrop2;

                Setpoint = systemLiquidExchanger.Setpoint?.Clone();
                //Setpoint2 = systemLiquidExchanger?.Setpoint2?.Clone();

                BypassPosition = systemLiquidExchanger.BypassPosition;
                SetpointPosition = systemLiquidExchanger.SetpointPosition;

                ExchangerCalculationMethod = systemLiquidExchanger.ExchangerCalculationMethod;

                ExchangerType = systemLiquidExchanger.ExchangerType;

                HeatTransferSurfaceArea = systemLiquidExchanger.HeatTransferSurfaceArea;

                HeatTransferCoefficient = systemLiquidExchanger.HeatTransferCoefficient;

                ScheduleName = systemLiquidExchanger.ScheduleName;
            }
        }

        public SystemLiquidExchanger(SystemLiquidExchanger systemLiquidExchanger)
            : base(systemLiquidExchanger)
        {
            if (systemLiquidExchanger != null)
            {
                Efficiency = systemLiquidExchanger.Efficiency?.Clone();

                Capacity1 = systemLiquidExchanger.Capacity1;
                Capacity2 = systemLiquidExchanger.Capacity2;
                
                DesignPressureDrop1 = systemLiquidExchanger.DesignPressureDrop1;
                DesignPressureDrop2 = systemLiquidExchanger.DesignPressureDrop2;

                Setpoint = systemLiquidExchanger.Setpoint?.Clone();
                //Setpoint2 = systemLiquidExchanger?.Setpoint2?.Clone();

                BypassPosition = systemLiquidExchanger.BypassPosition;
                SetpointPosition = systemLiquidExchanger.SetpointPosition;

                ExchangerCalculationMethod = systemLiquidExchanger.ExchangerCalculationMethod;

                ExchangerType = systemLiquidExchanger.ExchangerType;

                HeatTransferSurfaceArea = systemLiquidExchanger.HeatTransferSurfaceArea;

                HeatTransferCoefficient = systemLiquidExchanger.HeatTransferCoefficient;

                ScheduleName = systemLiquidExchanger.ScheduleName;
            }
        }

        public SystemLiquidExchanger(JsonObject jObject)
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

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("Capacity1"))
            {
                Capacity1 = jObject["Capacity1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity2"))
            {
                Capacity2 = jObject["Capacity2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject["DesignPressureDrop1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject["DesignPressureDrop2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            //if (jObject.ContainsKey("Setpoint2"))
            //{
            //    Setpoint2 = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint2"] as JsonObject);
            //}

            if (jObject.ContainsKey("BypassPosition"))
            {
                BypassPosition = Core.Query.Enum<ExchangerPosition>(jObject["BypassPosition"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("SetpointPosition"))
            {
                SetpointPosition = Core.Query.Enum<ExchangerPosition>(jObject["SetpointPosition"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ExchangerCalculationMethod"))
            {
                ExchangerCalculationMethod = Core.Query.Enum<ExchangerCalculationMethod>(jObject["ExchangerCalculationMethod"]?.GetValue<string>() ?? null);
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

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
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

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (!double.IsNaN(Capacity1))
            {
                result.Add("Capacity1", Capacity1);
            }

            if (!double.IsNaN(Capacity2))
            {
                result.Add("Capacity2", Capacity2);
            }

            if (!double.IsNaN(DesignPressureDrop1))
            {
                result.Add("DesignPressureDrop1", DesignPressureDrop1);
            }

            if (!double.IsNaN(DesignPressureDrop2))
            {
                result.Add("DesignPressureDrop2", DesignPressureDrop2);
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            //if (Setpoint2 != null)
            //{
            //    result.Add("Setpoint2", Setpoint2.ToJsonObject());
            //}

            result.Add("BypassPosition", BypassPosition.ToString());

            result.Add("SetpointPosition", SetpointPosition.ToString());

            result.Add("ExchangerCalculationMethod", ExchangerCalculationMethod.ToString());

            result.Add("ExchangerType", ExchangerType.ToString());

            if (!double.IsNaN(HeatTransferSurfaceArea))
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea);
            }

            if (!double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemLiquidExchanger(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
