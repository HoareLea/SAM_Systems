// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMaxLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Max;

        public SystemMaxLogicalController(string name)
            :base(name)
        {

        }

        public SystemMaxLogicalController(SystemMaxLogicalController systemMaxLogicalController)
            : base(systemMaxLogicalController)
        {
            if(systemMaxLogicalController != null)
            {

            }
        }

        public SystemMaxLogicalController(System.Guid guid, SystemMaxLogicalController systemMaxLogicalController)
            : base(guid, systemMaxLogicalController)
        {
            if (systemMaxLogicalController != null)
            {

            }
        }

        public SystemMaxLogicalController(JsonObject jObject)
            : base(jObject)
        {

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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMaxLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
