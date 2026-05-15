// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Analytical.Systems.Interfaces;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDesiccantWheel : SystemComponent, ISystemExchanger, IAirSystemComponent
    {
        public ModifiableValue SensibleEfficiency { get; set; }
        public ModifiableValue Reactivation { get; set; }
        public ModifiableValue MinimumRH { get; set; }
        public ModifiableValue MaximumRH { get; set; }
        public ModifiableValue SensibleHEEfficiency { get; set; }
        public ModifiableValue LatentHEEfficiency { get; set; }
        public SetpointMode HESetpointMethod { get; set; }
        public ModifiableValue HESetpoint { get; set; }
        public ModifiableValue ElectricalLoad { get; set; }

        public string ScheduleName { get; set; }


        public SystemDesiccantWheel(string name)
            : base(name)
        {

        }

        public SystemDesiccantWheel(SystemDesiccantWheel systemDesiccantWheel)
            : base(systemDesiccantWheel)
        {
            if(systemDesiccantWheel != null)
            {
                SensibleEfficiency = systemDesiccantWheel.SensibleEfficiency?.Clone();
                Reactivation = systemDesiccantWheel.Reactivation?.Clone();
                MinimumRH = systemDesiccantWheel.MinimumRH?.Clone();
                MaximumRH = systemDesiccantWheel.MaximumRH?.Clone();
                SensibleHEEfficiency = systemDesiccantWheel.SensibleHEEfficiency?.Clone();
                LatentHEEfficiency = systemDesiccantWheel.LatentHEEfficiency?.Clone();
                HESetpointMethod = systemDesiccantWheel.HESetpointMethod;
                HESetpoint = systemDesiccantWheel.HESetpoint?.Clone();
                ElectricalLoad = systemDesiccantWheel.ElectricalLoad?.Clone();
                ScheduleName = systemDesiccantWheel.ScheduleName;
            }
        }

        public SystemDesiccantWheel(System.Guid guid, SystemDesiccantWheel systemDesiccantWheel)
            : base(guid, systemDesiccantWheel)
        {
            if (systemDesiccantWheel != null)
            {
                SensibleEfficiency = systemDesiccantWheel.SensibleEfficiency?.Clone();
                Reactivation = systemDesiccantWheel.Reactivation?.Clone();
                MinimumRH = systemDesiccantWheel.MinimumRH?.Clone();
                MaximumRH = systemDesiccantWheel.MaximumRH?.Clone();
                SensibleHEEfficiency = systemDesiccantWheel.SensibleHEEfficiency?.Clone();
                LatentHEEfficiency = systemDesiccantWheel.LatentHEEfficiency?.Clone();
                HESetpointMethod = systemDesiccantWheel.HESetpointMethod;
                HESetpoint = systemDesiccantWheel.HESetpoint?.Clone();
                ElectricalLoad = systemDesiccantWheel.ElectricalLoad?.Clone();
                ScheduleName = systemDesiccantWheel.ScheduleName;
            }
        }

        public SystemDesiccantWheel(JsonObject jObject)
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

            if (jObject.ContainsKey("SensibleEfficiency"))
            {
                SensibleEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["SensibleEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("Reactivation"))
            {
                Reactivation = Core.Query.IJSAMObject<ModifiableValue>(jObject["Reactivation"] as JsonObject);
            }

            if (jObject.ContainsKey("MinimumRH"))
            {
                MinimumRH = Core.Query.IJSAMObject<ModifiableValue>(jObject["MinimumRH"] as JsonObject);
            }

            if (jObject.ContainsKey("MaximumRH"))
            {
                MaximumRH = Core.Query.IJSAMObject<ModifiableValue>(jObject["MaximumRH"] as JsonObject);
            }

            if (jObject.ContainsKey("SensibleHEEfficiency"))
            {
                SensibleHEEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["SensibleHEEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("LatentHEEfficiency"))
            {
                LatentHEEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["LatentHEEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HESetpointMethod"))
            {
                HESetpointMethod = Core.Query.Enum<SetpointMode>(jObject["HESetpointMethod"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("HESetpoint"))
            {
                HESetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["HESetpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["ElectricalLoad"] as JsonObject);
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

            if (SensibleEfficiency != null)
            {
                result.Add("SensibleEfficiency", SensibleEfficiency.ToJsonObject());
            }

            if (Reactivation != null)
            {
                result.Add("Reactivation", Reactivation.ToJsonObject());
            }

            if (MinimumRH != null)
            {
                result.Add("MinimumRH", MinimumRH.ToJsonObject());
            }

            if (MaximumRH != null)
            {
                result.Add("MaximumRH", MaximumRH.ToJsonObject());
            }

            if (SensibleHEEfficiency != null)
            {
                result.Add("SensibleHEEfficiency", SensibleHEEfficiency.ToJsonObject());
            }

            if (LatentHEEfficiency != null)
            {
                result.Add("LatentHEEfficiency", LatentHEEfficiency.ToJsonObject());
            }

            result.Add("HESetpointMethod", HESetpointMethod.ToString());

            if (HESetpoint != null)
            {
                result.Add("HESetpoint", HESetpoint.ToJsonObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJsonObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemDesiccantWheel(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
