// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSigLogicalController : SystemLogicalController
    {
        public override LogicalControllerType LogicalControllerType => LogicalControllerType.Sig;

        public SystemSigLogicalController(string name)
            :base(name)
        {

        }

        public SystemSigLogicalController(SystemSigLogicalController systemSigLogicalController)
            : base(systemSigLogicalController)
        {
            if(systemSigLogicalController != null)
            {

            }
        }

        public SystemSigLogicalController(System.Guid guid, SystemSigLogicalController systemSigLogicalController)
            : base(guid, systemSigLogicalController)
        {
            if (systemSigLogicalController != null)
            {

            }
        }

        public SystemSigLogicalController(JsonObject jObject)
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
            return new SystemSigLogicalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
