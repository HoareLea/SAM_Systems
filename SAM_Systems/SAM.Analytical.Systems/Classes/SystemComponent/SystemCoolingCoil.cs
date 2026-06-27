// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingCoil: SystemComponent, IAirSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue BypassFactor { get; set; }
        public ISizableValue Duty { get; set; }
        public ModifiableValue MinimumOffcoil { get; set; }

        public string ScheduleName { get; set; }

        public SystemCoolingCoil(string name)
            : base(name)
        {

        }

        public SystemCoolingCoil(SystemCoolingCoil systemCoolingCoil)
            : base(systemCoolingCoil)
        {
            if(systemCoolingCoil != null)
            {
                Setpoint = systemCoolingCoil.Setpoint?.Clone();
                BypassFactor = systemCoolingCoil.BypassFactor?.Clone();
                Duty = systemCoolingCoil.Duty?.Clone();
                MinimumOffcoil = systemCoolingCoil.MinimumOffcoil?.Clone();
                ScheduleName = systemCoolingCoil.ScheduleName;
            }
        }

        public SystemCoolingCoil(Guid guid, SystemCoolingCoil systemCoolingCoil)
            : base(guid, systemCoolingCoil)
        {
            if (systemCoolingCoil != null)
            {
                Setpoint = systemCoolingCoil.Setpoint?.Clone();
                BypassFactor = systemCoolingCoil.BypassFactor?.Clone();
                Duty = systemCoolingCoil.Duty?.Clone();
                MinimumOffcoil = systemCoolingCoil.MinimumOffcoil?.Clone();
                ScheduleName = systemCoolingCoil.ScheduleName;
            }
        }

        public SystemCoolingCoil(JsonObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject["BypassFactor"] as JsonObject);
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("MinimumOffcoil"))
            {
                MinimumOffcoil = Core.Query.IJSAMObject<ModifiableValue>(jObject["MinimumOffcoil"] as JsonObject);
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


            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJsonObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (MinimumOffcoil != null)
            {
                result.Add("MinimumOffcoil", MinimumOffcoil.ToJsonObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemCoolingCoil(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
