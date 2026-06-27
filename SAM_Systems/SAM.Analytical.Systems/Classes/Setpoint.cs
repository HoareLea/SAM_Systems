// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public abstract class Setpoint : ISetpoint
    {
        public Setpoint()
        {

        }

        public Setpoint(Setpoint setpoint)
        {

        }

        public Setpoint(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            return result;
        }
    }
}
