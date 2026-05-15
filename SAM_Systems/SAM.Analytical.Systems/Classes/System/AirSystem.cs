// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class AirSystem : FluidSystem
    {
        public AirSystem(AirSystem airSystem) 
            : base(airSystem)
        {
        }

        public AirSystem(System.Guid guid, AirSystem airSystem)
            : base(guid, airSystem)
        {
        }

        public AirSystem(JsonObject jObject)
            : base(jObject)
        {
        }

        public AirSystem(string name)
            : base(name)
        {
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            return base.ToJsonObject();
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new AirSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
