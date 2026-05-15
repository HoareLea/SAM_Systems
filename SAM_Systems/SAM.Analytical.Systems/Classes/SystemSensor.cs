// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSensor : SystemObject, ISystemSensor
    {       
        public SystemSensor()
            : base(string.Empty)
        {
        }

        public SystemSensor(string name)
            : base(name)
        {
        }

        public SystemSensor(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemSensor(SystemSensor systemSensor)
            : base(systemSensor)
        {

        }
        public SystemSensor(System.Guid guid, SystemSensor systemSensor)
            : base(guid, systemSensor)
        {

        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSensor(guid == null ? Guid.NewGuid() : guid.Value, this);
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
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

            return result;
        }
    }
}
