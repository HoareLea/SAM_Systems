// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Analytical.Systems.Interfaces;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Heat Recovery (Air Side)
    /// </summary>
    public class SystemExchanger : SystemComponent, ISystemExchanger, IAirSystemComponent
    {
        public ExchangerCalculationMethod ExchangerCalculationMethod { get; set; }
        public ExchangerType ExchangerType { get; set; }
        public ModifiableValue SensibleEfficiency { get; set; }
        public double HeatTransferSurfaceArea { get; set; }
        public double HeatTransferCoefficient { get; set; }
        public ExchangerLatentType ExchangerLatentType { get; set; }
        public ModifiableValue LatentEfficiency { get; set; }
        public SetpointMode SetpointMode { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue ElectricalLoad { get; set; }
        public ISizableValue Duty { get; set; }
        public ModifiableValue BypassFactor { get; set; }
        public bool HeatingOnly { get; set; }
        public bool AdjustForOptimiser { get; set; }
        public string ScheduleName { get; set; }

        public SystemExchanger(string name)
            : base(name)
        {

        }

        public SystemExchanger(SystemExchanger systemExchanger)
            : base(systemExchanger)
        {
            if(systemExchanger != null)
            {
                ExchangerCalculationMethod = systemExchanger.ExchangerCalculationMethod;
                ExchangerType = systemExchanger.ExchangerType;
                SensibleEfficiency = systemExchanger.SensibleEfficiency?.Clone();
                HeatTransferSurfaceArea = systemExchanger.HeatTransferSurfaceArea;
                HeatTransferCoefficient = systemExchanger.HeatTransferCoefficient;
                ExchangerLatentType = systemExchanger.ExchangerLatentType;
                LatentEfficiency = systemExchanger.LatentEfficiency?.Clone();
                SetpointMode = systemExchanger.SetpointMode;
                Setpoint = systemExchanger.Setpoint?.Clone();
                ElectricalLoad = systemExchanger.ElectricalLoad?.Clone();
                Duty = systemExchanger.Duty?.Clone();
                BypassFactor = systemExchanger.BypassFactor?.Clone();
                ScheduleName = systemExchanger.ScheduleName;
                HeatingOnly = systemExchanger.HeatingOnly;
                AdjustForOptimiser = systemExchanger.AdjustForOptimiser;
            }
        }

        public SystemExchanger(System.Guid guid, SystemExchanger systemExchanger)
            : base(guid, systemExchanger)
        {
            if (systemExchanger != null)
            {
                ExchangerCalculationMethod = systemExchanger.ExchangerCalculationMethod;
                ExchangerType = systemExchanger.ExchangerType;
                SensibleEfficiency = systemExchanger.SensibleEfficiency?.Clone();
                HeatTransferSurfaceArea = systemExchanger.HeatTransferSurfaceArea;
                HeatTransferCoefficient = systemExchanger.HeatTransferCoefficient;
                ExchangerLatentType = systemExchanger.ExchangerLatentType;
                LatentEfficiency = systemExchanger.LatentEfficiency?.Clone();
                SetpointMode = systemExchanger.SetpointMode;
                Setpoint = systemExchanger.Setpoint?.Clone();
                ElectricalLoad = systemExchanger.ElectricalLoad?.Clone();
                Duty = systemExchanger.Duty?.Clone();
                BypassFactor = systemExchanger.BypassFactor?.Clone();
                ScheduleName = systemExchanger.ScheduleName;
                HeatingOnly = systemExchanger.HeatingOnly;
                AdjustForOptimiser = systemExchanger.AdjustForOptimiser;
            }
        }

        public SystemExchanger(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 2),
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

            if (jObject.ContainsKey("ExchangerCalculationMethod"))
            {
                ExchangerCalculationMethod = Core.Query.Enum<ExchangerCalculationMethod>(jObject["ExchangerCalculationMethod"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ExchangerType"))
            {
                ExchangerType = Core.Query.Enum<ExchangerType>(jObject["ExchangerType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("SensibleEfficiency"))
            {
                SensibleEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["SensibleEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = jObject["HeatTransferSurfaceArea"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("ExchangerLatentType"))
            {
                ExchangerLatentType = Core.Query.Enum<ExchangerLatentType>(jObject["ExchangerLatentType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("LatentEfficiency"))
            {
                LatentEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["LatentEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("SetpointMode"))
            {
                SetpointMode = Core.Query.Enum<SetpointMode>(jObject["SetpointMode"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["ElectricalLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject["BypassFactor"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingOnly"))
            {
                HeatingOnly = jObject["HeatingOnly"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("AdjustForOptimiser"))
            {
                AdjustForOptimiser = jObject["AdjustForOptimiser"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            result.Add("ExchangerCalculationMethod", ExchangerCalculationMethod.ToString());

            result.Add("ExchangerType", ExchangerType.ToString());

            if (SensibleEfficiency != null)
            {
                result.Add("SensibleEfficiency", SensibleEfficiency.ToJsonObject());
            }

            if (double.IsNaN(HeatTransferSurfaceArea))
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea);
            }

            if (double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            result.Add("ExchangerLatentType", ExchangerLatentType.ToString());

            if (LatentEfficiency != null)
            {
                result.Add("LatentEfficiency", LatentEfficiency.ToJsonObject());
            }

            result.Add("SetpointMode", SetpointMode.ToString());

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJsonObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJsonObject());
            }

            result.Add("HeatingOnly", HeatingOnly);

            result.Add("AdjustForOptimiser", AdjustForOptimiser);

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemExchanger(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
