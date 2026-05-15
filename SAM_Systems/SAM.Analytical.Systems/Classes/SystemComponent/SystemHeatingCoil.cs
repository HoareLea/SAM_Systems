// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemHeatingCoil : SystemComponent, IAirSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ISizableValue Duty { get; set; }
        public ModifiableValue MaximumOffcoil { get; set; }

        public double ControlBand { get; set; }

        public string ScheduleName { get; set; }

        public SystemHeatingCoil(string name)
            : base(name)
        {

        }

        public SystemHeatingCoil(SystemHeatingCoil systemHeatingCoil)
            : base(systemHeatingCoil)
        {
            if(systemHeatingCoil != null)
            {
                Setpoint = systemHeatingCoil.Setpoint?.Clone();
                Efficiency = systemHeatingCoil.Efficiency?.Clone();
                Duty = systemHeatingCoil.Duty?.Clone();
                MaximumOffcoil = systemHeatingCoil.MaximumOffcoil?.Clone();
                
                ControlBand = systemHeatingCoil.ControlBand;

                ScheduleName = systemHeatingCoil.ScheduleName;
            }
        }

        public SystemHeatingCoil(Guid guid, SystemHeatingCoil systemHeatingCoil)
            : base(guid, systemHeatingCoil)
        {
            if (systemHeatingCoil != null)
            {
                Setpoint = systemHeatingCoil.Setpoint?.Clone();
                Efficiency = systemHeatingCoil.Efficiency?.Clone();
                Duty = systemHeatingCoil.Duty?.Clone();
                MaximumOffcoil = systemHeatingCoil.MaximumOffcoil?.Clone();

                ControlBand = systemHeatingCoil.ControlBand;

                ScheduleName = systemHeatingCoil.ScheduleName;
            }
        }

        public SystemHeatingCoil(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>(),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(Direction.In)
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

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("MaximumOffcoil"))
            {
                MaximumOffcoil = Core.Query.IJSAMObject<ModifiableValue>(jObject["MaximumOffcoil"] as JsonObject);
            }

            if (jObject.ContainsKey("ControlBand"))
            {
                ControlBand = jObject["ControlBand"]?.GetValue<double>() ?? default(double);
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
                return null;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (MaximumOffcoil != null)
            {
                result.Add("MaximumOffcoil", MaximumOffcoil.ToJsonObject());
            }

            if (!double.IsNaN(ControlBand))
            {
                result.Add("ControlBand", ControlBand);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemHeatingCoil(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
