// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemChilledBeam : SystemSpaceComponent
    {
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public ModifiableValue BypassFactor { get; set; }
        public ModifiableValue HeatingEfficiency { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public SystemSpaceComponentPosition ZonePosition { get; set; }
        public string ScheduleName { get; set; }

        public bool Heating { get; set; }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1)
                );
            }
        }

        public SystemChilledBeam(string name)
            : base(name)
        {
        }

        public SystemChilledBeam(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemChilledBeam(SystemChilledBeam systemChilledBeam)
            : base(systemChilledBeam)
        {
            if (systemChilledBeam != null)
            {
                HeatingDuty = systemChilledBeam.HeatingDuty?.Clone();
                CoolingDuty = systemChilledBeam.CoolingDuty?.Clone();
                BypassFactor = systemChilledBeam.BypassFactor?.Clone();
                HeatingEfficiency = systemChilledBeam.HeatingEfficiency?.Clone();
                DesignFlowRate = systemChilledBeam.DesignFlowRate?.Clone();
                DesignFlowType = systemChilledBeam.DesignFlowType;
                ZonePosition = systemChilledBeam.ZonePosition;
                ScheduleName = systemChilledBeam.ScheduleName;
                Heating = systemChilledBeam.Heating;
            }
        }

        public SystemChilledBeam(Guid guid, SystemChilledBeam systemChilledBeam)
            : base(guid, systemChilledBeam)
        {
            if (systemChilledBeam != null)
            {
                HeatingDuty = systemChilledBeam.HeatingDuty?.Clone();
                CoolingDuty = systemChilledBeam.CoolingDuty?.Clone();
                BypassFactor = systemChilledBeam.BypassFactor?.Clone();
                HeatingEfficiency = systemChilledBeam.HeatingEfficiency?.Clone();
                DesignFlowRate = systemChilledBeam.DesignFlowRate?.Clone();
                DesignFlowType = systemChilledBeam.DesignFlowType;
                ZonePosition = systemChilledBeam.ZonePosition;
                ScheduleName = systemChilledBeam.ScheduleName;
                Heating = systemChilledBeam.Heating;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["HeatingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["CoolingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject["BypassFactor"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject["DesignFlowRate"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignFlowType"))
            {
                DesignFlowType = Core.Query.Enum<FlowRateType>(jObject["DesignFlowType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ZonePosition"))
            {
                ZonePosition = Core.Query.Enum<SystemSpaceComponentPosition>(jObject["ZonePosition"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("Heating"))
            {
                Heating = jObject["Heating"]?.GetValue<bool>() ?? default(bool);
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

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJsonObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJsonObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJsonObject());
            }

            if (HeatingEfficiency != null)
            {
                result.Add("HeatingEfficiency", HeatingEfficiency.ToJsonObject());
            }

            if (DesignFlowRate != null)
            {
                result.Add("DesignFlowRate", DesignFlowRate.ToJsonObject());
            }

            result.Add("DesignFlowType", DesignFlowType.ToString());

            result.Add("ZonePosition", ZonePosition.ToString());

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            result.Add("Heating", Heating);

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemChilledBeam(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}

