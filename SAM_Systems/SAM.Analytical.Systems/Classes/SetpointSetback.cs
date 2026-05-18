// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public class SetpointSetback : Setback
    {
        private ISetpoint setpoint;

        public SetpointSetback()
        {

        }

        public SetpointSetback(string scheduleName, ISetpoint setpoint)
            :base(scheduleName)
        {
            this.setpoint = setpoint == null ? null : Core.Query.Clone(setpoint);
        }

        public SetpointSetback(SetpointSetback setpointSetback)
            :base(setpointSetback)
        {
            if(setpointSetback != null)
            {
                setpoint = setpointSetback.setpoint == null ? null : Core.Query.Clone(setpointSetback.setpoint);
            }
        }

        public SetpointSetback(JsonObject jObject)
            : base(jObject)
        {

        }

        public ISetpoint Setpoint
        {
            get
            {
                return Core.Query.Clone(setpoint);
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
                setpoint = Core.Query.IJSAMObject<ISetpoint>(jObject["Setpoint"] as JsonObject);
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

            if (setpoint != null)
            {
                result.Add("Setpoint", setpoint.ToJsonObject());
            }

            return result;
        }
    }
}
