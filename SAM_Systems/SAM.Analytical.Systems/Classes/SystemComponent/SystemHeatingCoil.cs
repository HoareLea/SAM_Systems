﻿using Newtonsoft.Json.Linq;
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
                ScheduleName = systemHeatingCoil.ScheduleName;
            }
        }

        public SystemHeatingCoil(System.Guid guid, SystemHeatingCoil systemHeatingCoil)
            : base(guid, systemHeatingCoil)
        {
            if (systemHeatingCoil != null)
            {
                Setpoint = systemHeatingCoil.Setpoint?.Clone();
                Efficiency = systemHeatingCoil.Efficiency?.Clone();
                Duty = systemHeatingCoil.Duty?.Clone();
                MaximumOffcoil = systemHeatingCoil.MaximumOffcoil?.Clone();
                ScheduleName = systemHeatingCoil.ScheduleName;
            }
        }

        public SystemHeatingCoil(JObject jObject)
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

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("MaximumOffcoil"))
            {
                MaximumOffcoil = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MaximumOffcoil"));
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
                return null;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (MaximumOffcoil != null)
            {
                result.Add("MaximumOffcoil", MaximumOffcoil.ToJObject());
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
