// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDXCoil : SystemComponent, IAirSystemComponent
    {
        public ModifiableValue CoolingSetpoint { get; set; }
        public ModifiableValue HeatingSetpoint { get; set; }

        public ModifiableValue MinOffcoilTemperature { get; set; }
        public ModifiableValue MaxOffcoilTemperature { get; set; }

        public ModifiableValue BypassFactor { get; set; }

        public ISizableValue CoolingDuty { get; set; }
        public ISizableValue HeatingDuty { get; set; }

        public string ScheduleName { get; set; }

        public SystemDXCoil(string name)
            : base(name)
        {

        }

        public SystemDXCoil(SystemDXCoil systemDXCoil)
            : base(systemDXCoil)
        {
            if (systemDXCoil != null)
            {
                CoolingSetpoint = systemDXCoil.CoolingSetpoint.Clone();
                HeatingSetpoint = systemDXCoil.HeatingSetpoint.Clone();
                MinOffcoilTemperature = systemDXCoil.MinOffcoilTemperature.Clone();
                MaxOffcoilTemperature = systemDXCoil.MaxOffcoilTemperature.Clone();
                BypassFactor = systemDXCoil.BypassFactor.Clone();
                CoolingDuty = systemDXCoil.CoolingDuty.Clone();
                HeatingDuty = systemDXCoil.HeatingDuty.Clone();
                ScheduleName = systemDXCoil.ScheduleName;
            }
        }

        public SystemDXCoil(System.Guid guid, SystemDXCoil systemDXCoil)
            : base(guid, systemDXCoil)
        {
            if (systemDXCoil != null)
            {
                CoolingSetpoint = systemDXCoil.CoolingSetpoint.Clone();
                HeatingSetpoint = systemDXCoil.HeatingSetpoint.Clone();
                MinOffcoilTemperature = systemDXCoil.MinOffcoilTemperature.Clone();
                MaxOffcoilTemperature = systemDXCoil.MaxOffcoilTemperature.Clone();
                BypassFactor = systemDXCoil.BypassFactor.Clone();
                CoolingDuty = systemDXCoil.CoolingDuty.Clone();
                HeatingDuty = systemDXCoil.HeatingDuty.Clone();
                ScheduleName = systemDXCoil.ScheduleName;
            }
        }

        public SystemDXCoil(JsonObject jObject)
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
                    //Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.In, 2),
                    //Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.Out, 2),
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

            if (jObject.ContainsKey("CoolingSetpoint"))
            {
                CoolingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["CoolingSetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingSetpoint"))
            {
                HeatingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingSetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("MinOffcoilTemperature"))
            {
                MinOffcoilTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject["MinOffcoilTemperature"] as JsonObject);
            }

            if (jObject.ContainsKey("MaxOffcoilTemperature"))
            {
                MaxOffcoilTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject["MaxOffcoilTemperature"] as JsonObject);
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject["BypassFactor"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["CoolingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["HeatingDuty"] as JsonObject);
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

            if (CoolingSetpoint != null)
            {
                result.Add("CoolingSetpoint", CoolingSetpoint.ToJsonObject());
            }

            if (HeatingSetpoint != null)
            {
                result.Add("HeatingSetpoint", HeatingSetpoint.ToJsonObject());
            }

            if (MinOffcoilTemperature != null)
            {
                result.Add("MinOffcoilTemperature", MinOffcoilTemperature.ToJsonObject());
            }

            if (MaxOffcoilTemperature != null)
            {
                result.Add("MaxOffcoilTemperature", MaxOffcoilTemperature.ToJsonObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJsonObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJsonObject());
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJsonObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemDXCoil(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
