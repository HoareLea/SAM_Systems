// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemNotLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Not;

        public SystemNotLogicalController(string name)
            :base(name)
        {

        }

        public SystemNotLogicalController(SystemNotLogicalController systemNotLogicalController)
            : base(systemNotLogicalController)
        {
            if(systemNotLogicalController != null)
            {

            }
        }

        public SystemNotLogicalController(System.Guid guid, SystemNotLogicalController systemNotLogicalController)
            : base(guid, systemNotLogicalController)
        {
            if (systemNotLogicalController != null)
            {

            }
        }

        public SystemNotLogicalController(JsonObject jObject)
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
            return new SystemNotLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
