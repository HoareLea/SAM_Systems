// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystem : SystemObject, IElectricalSystem
    {
        public ElectricalSystem(string name)
            : base(name)
        {
        }

        public ElectricalSystem(System.Guid guid, ElectricalSystem electricalSystem)
            : base(guid, electricalSystem)
        {
        }

        public ElectricalSystem(ElectricalSystem electricalSystem)
            : base(electricalSystem)
        {
        }

        public ElectricalSystem(JsonObject jObject)
            : base(jObject)
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
            return new ElectricalSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
